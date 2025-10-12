// 代码生成时间: 2025-10-13 03:00:31
 * @author [Your Name]
 * @date [Date]
 */
using UnityEngine;
using UnityEngine.UI;

public class DateTimePicker : MonoBehaviour
{
    [SerializeField]
    private Dropdown monthDropdown;
    [SerializeField]
    private Dropdown dayDropdown;
    [SerializeField]
    private Dropdown yearDropdown;
    [SerializeField]
    private Dropdown hourDropdown;
    [SerializeField]
    private Dropdown minuteDropdown;
    [SerializeField]
    private Button confirmButton;
    [SerializeField]
    private Text dateDisplay;

    private int selectedYear;
    private int selectedMonth;
    private int selectedDay;
    private int selectedHour;
    private int selectedMinute;

    private const int START_YEAR = 1900;
    private const int END_YEAR = 2100;

    private void Start()
    {
        // Initialize the dropdowns with the appropriate values
        InitializeYearDropdown();
        InitializeMonthDropdown();
        InitializeDayDropdown();
        InitializeHourDropdown();
        InitializeMinuteDropdown();
    }

    private void InitializeYearDropdown()
    {
        for (int year = START_YEAR; year <= END_YEAR; year++)
        {
            yearDropdown.options.Add(new Dropdown.OptionData(year.ToString()));
        }
        yearDropdown.value = System.DateTime.Today.Year;
        yearDropdown.RefreshShownValue();
        selectedYear = System.DateTime.Today.Year;
    }

    private void InitializeMonthDropdown()
    {
        for (int month = 1; month <= 12; month++)
        {
            monthDropdown.options.Add(new Dropdown.OptionData(month.ToString("D2")));
        }
        monthDropdown.value = System.DateTime.Today.Month;
        monthDropdown.RefreshShownValue();
        selectedMonth = System.DateTime.Today.Month;
    }

    private void InitializeDayDropdown()
    {
        for (int day = 1; day <= DateTime.DaysInMonth(selectedYear, selectedMonth); day++)
        {
            dayDropdown.options.Add(new Dropdown.OptionData(day.ToString("D2")));
        }
        dayDropdown.value = System.DateTime.Today.Day;
        dayDropdown.RefreshShownValue();
        selectedDay = System.DateTime.Today.Day;
    }

    private void InitializeHourDropdown()
    {
        for (int hour = 0; hour < 24; hour++)
        {
            hourDropdown.options.Add(new Dropdown.OptionData(hour.ToString("D2")));
        }
        hourDropdown.value = System.DateTime.Now.Hour;
        hourDropdown.RefreshShownValue();
        selectedHour = System.DateTime.Now.Hour;
    }

    private void InitializeMinuteDropdown()
    {
        for (int minute = 0; minute < 60; minute++)
        {
            minuteDropdown.options.Add(new Dropdown.OptionData(minute.ToString("D2")));
        }
        minuteDropdown.value = System.DateTime.Now.Minute;
        minuteDropdown.RefreshShownValue();
        selectedMinute = System.DateTime.Now.Minute;
    }

    public void OnConfirmButtonPressed()
    {
        try
        {
            DateTime selectedDateTime = new DateTime(selectedYear, selectedMonth, selectedDay, selectedHour, selectedMinute, 0);
            dateDisplay.text = selectedDateTime.ToString("yyyy-MM-dd HH:mm");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error selecting date and time: " + ex.Message);
        }
    }

    // Allow external scripts to set the selected date and time
    public void SetDateTime(DateTime dateTime)
    {
        selectedYear = dateTime.Year;
        selectedMonth = dateTime.Month;
        selectedDay = dateTime.Day;
        selectedHour = dateTime.Hour;
        selectedMinute = dateTime.Minute;

        // Update dropdowns
        yearDropdown.value = selectedYear;
        monthDropdown.value = selectedMonth;
        dayDropdown.value = selectedDay;
        hourDropdown.value = selectedHour;
        minuteDropdown.value = selectedMinute;

        yearDropdown.RefreshShownValue();
        monthDropdown.RefreshShownValue();
        dayDropdown.RefreshShownValue();
        hourDropdown.RefreshShownValue();
        minuteDropdown.RefreshShownValue();
    }
}
