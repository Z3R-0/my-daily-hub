namespace my_daily_hub_frontend.Pages;
public partial class Habits {
    private const int TimerDelay = 1000;
    private const string TwentyFourHourClockTimeFormat = "HH:mm:ss";

    private string timeOfDayGreeting = "";
    private string currentTime = "";
    private string newHabit = "";
    private string currentHabit = "";

    private Timer? timer;

    protected override async Task OnInitializedAsync() {
        timeOfDayGreeting = GetTimeOfDayGreeting();
        UpdateCurrentTime();

        currentHabit = await _localStorageService.GetItemAsync("habit") ?? "";

        timer = new Timer(UpdateTime, null, 0, TimerDelay);
    }

    private void UpdateTime(object? state) {
        UpdateCurrentTime();
        InvokeAsync(StateHasChanged);
    }

    private string GetTimeOfDayGreeting() {
        var currentHour = _dateTimeProvider.UtcNow().Hour;

        if (currentHour < 12)
            return "morning";
        else if (currentHour < 18)
            return "afternoon";
        else
            return "evening";
    }

    private void UpdateCurrentTime() {
        currentTime = _dateTimeProvider.UtcNow().ToString(TwentyFourHourClockTimeFormat);
    }

    private async Task HandleSubmitAsync() {
        await _localStorageService.SetItemAsync("habit", newHabit);
        currentHabit = newHabit;
        StateHasChanged();
    }

    public void Dispose() {
        timer?.Dispose();
    }
}