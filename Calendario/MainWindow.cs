using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;


namespace CalendarProject
{
    public partial class MainWindow : Form
    {
        DateTime showingDate;
        
        public MainWindow()
        {
            showingDate = DateTime.Now;
            InitializeComponent();

        }

        private void MainWindowLoad(object sender, EventArgs e)
        {
            
            DrawCalendar();
        }



        private void DrawCalendar()
        {
            Calendar.Rows.Clear();
            currentDateTitle.Text = $"{showingDate.ToString(Constants.monthFormat, CultureInfo.InvariantCulture)} {showingDate.Year.ToString()}".ToUpper();
            DateTime firstDayOfTargetMonth = new DateTime(showingDate.Year, showingDate.Month, Constants.IndexToCreateMonth);
            int currentMonthDays = DateTime.DaysInMonth(firstDayOfTargetMonth.Year, firstDayOfTargetMonth.Month);
            int firstDayIndexOnWeek = (int)firstDayOfTargetMonth.DayOfWeek;

            if (firstDayIndexOnWeek == (int)DayOfWeek.Sunday)
            {
                firstDayIndexOnWeek = Constants.sundayIndex;
            }

            firstDayIndexOnWeek = firstDayIndexOnWeek - Constants.indexNormalizer;
            int dayCounter = firstDayOfTargetMonth.Day;
            List<string> currentWeektoInsert;

            for (int weekNumber = Constants.firstWeekOfMonth; weekNumber < Constants.WeeksToShowOnCalendar; weekNumber++)
            {
                currentWeektoInsert = InitializeEmptyWeek();
                if (weekNumber == Constants.firstWeekOfMonth)
                {
                    for (int currentDayIndex = firstDayIndexOnWeek; currentDayIndex <= Constants.daysIndexInWeek; currentDayIndex++)
                    {
                        currentWeektoInsert[currentDayIndex] = dayCounter.ToString();
                        dayCounter++;
                    }
                }
                else
                {
                    for (int currentDayIndex = Constants.firstDayOfWeekIndex; currentDayIndex <= Constants.daysIndexInWeek; currentDayIndex++)
                    {
                        currentWeektoInsert[currentDayIndex] = dayCounter.ToString();
                        dayCounter++;
                        if (DaysLimitReached(dayCounter, currentMonthDays))
                        {
                            break;
                        }
                    }
                }
                Calendar.Rows.Add(currentWeektoInsert.ToArray());
                if (DaysLimitReached(dayCounter, currentMonthDays))
                {
                    return;
                }
            }
        }


        private bool DaysLimitReached(int dayCounter, int daysInMonth)
        {
            if (dayCounter > daysInMonth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

        private List<string> InitializeEmptyWeek()
        {
            List<string> emptyWeek = new List<string> { };
            for (int dayIndex = Constants.firstDayOfWeekIndex; dayIndex <= Constants.daysIndexInWeek; dayIndex++)
            {
                emptyWeek.Add(Constants.dayPlaceHolder);
            }
            return emptyWeek;

        }

        private void NextMonthClick(object sender, EventArgs e)
        {
            showingDate = showingDate.AddMonths(Constants.nextMonthInterval);
            DrawCalendar();
        }

        private void PreviousMonthClick(object sender, EventArgs e)
        {
            showingDate = showingDate.AddMonths(Constants.previousMonthInterval);
            DrawCalendar();
        }

        
    }
}
