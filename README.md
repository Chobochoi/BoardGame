# BoardGame
- 연습용도
- 씹어먹는 C++
```
using System;
using System.Text;

namespace Calendar
{
    class Program
    {
        static List<int> allMonthDays = new List<int> { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        static void Main(string[] args)
        {
            Console.WriteLine("원하는 달력 연도를 입력 : ");
            int year = int.Parse(Console.ReadLine());

            StringBuilder calendar = new StringBuilder();

            for (int month = 0; month < 12; month++)
            {
                // 월을 케이스로 분류해서 1월 부터 12월까지 입력되게 하기
                calendar.AppendLine(WhatMonthName(month));

                // 캘린더에 요일 입력하기 (꾸미기 용)
                calendar.AppendLine("====================");
                calendar.AppendLine("일 월 화 수 목 금 토");
                calendar.AppendLine("====================");

                // 첫번째 날 부터 표시하기
                //int firstDayOfMonth = GetFirstDayOfMonth(year, month);
                int firstDay = GetFirstDayOfMonth(year, month, 1);
                //calendar.Append(' ', firstDayOfMonth * 3);
                calendar.Append(' ', firstDay * 3);

                //int totalDays = PreMonthTotalDays(year, month);

                //윤년이면 날을 하루 더 더해주기
                int days = allMonthDays[month];
                if (month == 1 && YunYear(year))
                {
                    days++;
                }

                // 날 마다 하루씩 더해주기, (토요일 = 7)이 되면 개행하기
                for (int day = 1; day <= days; day++)
                {
                    calendar.Append(day.ToString().PadLeft(2));
                    calendar.Append(' ');
                    if ((day + firstDay) % 7 == 0)
                    {
                        calendar.AppendLine();
                    }
                }

                calendar.AppendLine();
                calendar.AppendLine("=====================");
            }

            // 캘린더 그리기
            Console.WriteLine(calendar.ToString());
        }

        static string WhatMonthName(int month)
        {
            switch (month)
            {
                case 0: return "\t1월";
                case 1: return "\t2월";
                case 2: return "\t3월";
                case 3: return "\t4월";
                case 4: return "\t5월";
                case 5: return "\t6월";
                case 6: return "\t7월";
                case 7: return "\t8월";
                case 8: return "\t9월";
                case 9: return "\t10월";
                case 10: return "\t11월";
                case 11: return "\t12월";
                default: return "";
            }
        }       

        static int GetFirstDayOfMonth(int year, int month, int nowDay)
        {            
            //int firstDayOfMonth = (year / 100 + year % 100 / 4 + month + 5) % 7;
            //if (month <= 1 && YunYear(year))
            //{
            //    firstDayOfMonth = (firstDayOfMonth + 6) % 7;
            //}
            //return firstDayOfMonth;

            int preMonthtotalDays = 0;            

            // 전달까지 총일 수를 구한다.
            preMonthtotalDays = PreMonthTotalDays(year, month);

            // 구하는 달 1일의 요일을 구한다.
            int firstDay = (preMonthtotalDays + nowDay) % 7;

            return firstDay;
        }

        public static int PreMonthTotalDays(int year, int month)
        {
            int totalDays = 0;
            int preYear = year - 1;
            totalDays = preYear * 365 + (preYear / 4 + preYear / 400 - preYear / 100);

            // 대상 년도의 이전 달까지 날짜 수를 구한다.
            for (int i = 0; i < month - 1; i++)
            {
                // 1월부터 전달까지 날짜를 더한다
                totalDays += allMonthDays[i];
            }

            // 이번 년도가 윤년 여부 확인해 1일 추가 한다.
            if (month >= 3 && YunYear(year))
            {
                totalDays += 1;
            }
            return totalDays;
        }

        public static bool YunYear(int year)
        {
            if ((year % 4 == 0 || year % 400 == 0) && year % 100 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
```

- 2023/02/06
```
using System.Drawing;
using System.Text;

namespace Calendar
{
    // 신규 개발자 교육 (캘린더 만들기)
    // Point 1 : 특정일이 무슨 요일인지 구하는 알고리즘을 직접 구현.
    // Point 2 : 주 단위 줄 바꿈, 월별 날짜 덧셈 등의 기능을 어떻게 구현 할 것인가.
    // Point 3 : 꾸미기( 4 x 3 ), Text 색 입히기 등..

    // 2023/02/08 코드리뷰 진행
    // 2023/02/06 문제점1 : 1월과 2월이 같이 나옴. (완료) Month에 -1을 하여 1월과 2월 시작이 동일 취급 
    // 2023/02/06 문제점2 : 윤년은 적용됨 하지만 윤년일 때 3월이 + 1 되어서 나오면서 정렬이 맞지 않음. (완료)

    class Program
    {   
        static List<int> allMonthDays = new List<int> { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        static void Main(string[] args)
        {
            Console.WriteLine("원하는 달력 연도를 입력 : ");
            int year = int.Parse(Console.ReadLine());

            StringBuilder calendar = new StringBuilder();

            for (int month = 0; month < 12; month++)
            {
                // 월을 케이스로 분류해서 1월 부터 12월까지 입력되게 하기
                calendar.AppendLine(WhatMonthName(month));

                // 캘린더에 요일 입력하기
                calendar.AppendLine("====================");                
                calendar.AppendLine("일 월 화 수 목 금 토");
                calendar.AppendLine("====================");                              

                // 첫번째 날 부터 표시하기                
                int firstDay = FirstDayOfMonth(year, month, 1);
                calendar.Append(' ', firstDay * 3);                

                // 윤년이면 날을 하루 더 더해주기
                int days = allMonthDays[month];
                if (month == 1 && YunYear(year))
                {
                    days++;
                }

                // 윤년일 때의 3월 정렬
                // 윤년일 때의 값은 잘 나왔으나 요일 표시와 날짜 표시가 달라 calendar.Append("   ") 로 정렬 맞춤.
                if (month == 2 && YunYear(year))
                {
                    firstDay++;
                    calendar.Append("   ");

                    if (firstDay % 7 == 0)
                    {
                        calendar.AppendLine();
                    }
                }

                // 날 마다 하루씩 더해주기, (토요일 = 7)이 되면 개행하기
                for (int day = 1; day <= days; day++)
                {
                    calendar.Append(day.ToString().PadLeft(2));
                    calendar.Append(' ');

                    if ((day + firstDay) % 7 == 0)
                    {
                        calendar.AppendLine();
                    }
                }
                calendar.AppendLine();
                calendar.AppendLine("====================");
            }

            // 캘린더 그리기
            Console.WriteLine(calendar.ToString());
        }       

        public static string WhatMonthName(int month)
        {
            switch (month)
            {
                case 0: return "\t1월";
                case 1: return "\t2월";
                case 2: return "\t3월";
                case 3: return "\t4월";
                case 4: return "\t5월";
                case 5: return "\t6월";
                case 6: return "\t7월";
                case 7: return "\t8월";
                case 8: return "\t9월";
                case 9: return "\t10월";
                case 10: return "\t11월";
                case 11: return "\t12월";
                default: return "";
            }
        }

        public static int FirstDayOfMonth(int year, int month, int nowDay)
        {
            int preMonthtotalDays = 0;

            // 전달까지 총일 수를 구한다.
            preMonthtotalDays = PreMonthTotalDays(year, month);

            // 구하는 달 1일의 요일을 구한다.
            int firstDay = (preMonthtotalDays + nowDay) % 7;

            return firstDay;
        }

        public static int PreMonthTotalDays(int year, int month)
        {
            int totalDays = 0;
            int preYear = year - 1;
            totalDays = preYear * 365 + (preYear / 4 + preYear / 400 - preYear / 100);

            // 대상 년도의 날짜 수를 구한다.
            for (int i = 0; i < month; i++)
            {
                // 1월부터 전달까지 날짜를 더한다
                totalDays += allMonthDays[i];
            }

            // 이번 년도가 윤년 여부 확인해 1일 추가 한다.
            if (month >= 3 && YunYear(year))
            {
                totalDays += 1;
            }
            return totalDays;
        }

        // 윤년 체크
        public static bool YunYear(int year)
        {
            if ((year % 4 == 0 || year % 400 == 0) && year % 100 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }        
    }
}
```

```namespace Calendar
{
    // 신규 개발자 교육 (캘린더 만들기)
    // Point 1 : 특정일이 무슨 요일인지 구하는 알고리즘을 직접 구현.
    // Point 2 : 주 단위 줄 바꿈, 월별 날짜 덧셈 등의 기능을 어떻게 구현 할 것인가.
    // Point 3 : 꾸미기( 4 x 3 ), Text 색 입히기 등..

    // 2023/02/08 코드리뷰 진행
    // 2023/02/06 문제점1 : 1월과 2월이 같이 나옴. (완료) Month에 -1을 하여 1월과 2월 시작이 동일 취급 
    // 2023/02/06 문제점2 : 윤년은 적용됨 하지만 윤년일 때 3월이 + 1 되어서 나오면서 정렬이 맞지 않음. (완료)

    class Program
    {
        static List<int> allMonthDays = new List<int> { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        //string[] month = { "1월", "2월", "3월", "4월", "5월", "6월", "7월", "8월", "9월", "10월", "11월", "12월" };;

        static void Main(string[] args)
        {
            Console.WriteLine("원하는 달력 연도를 입력 : ");
            
            int year = int.Parse(Console.ReadLine());
            
            
            for (int month = 0; month < 12; month++)
            {
                Console.WriteLine(WhatMonthName(month));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("일");
                Console.ResetColor();
                Console.Write("\t월\t화\t수\t목\t금\t");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("토");
                Console.ResetColor();


                //int totalDays = TotalMonthDays(year, month);
                int startDay = FirstDayOfMonth(year, month, 1);
                Console.WriteLine("\n");          
                            
                //int days = allMonthDays[month];
                //if (month == 1 && YunYear(year))
                //{
                //    days++;
                //}

                //for (int day = 1; day <= days; day++)
                //{
                //    int test = day + startDay % 7;

                //    if (test == 0)
                //    {
                //        Console.ForegroundColor = ConsoleColor.Red;
                //        Console.WriteLine();
                //    }

                //    if (test == 6)
                //    {
                //        Console.ForegroundColor = ConsoleColor.Blue;
                //        Console.WriteLine();
                //    }
                //    Console.Write("\t" + day);
                //    Console.ResetColor();
                    
                //}              
            DisplayCalendar(year, month, startDay);

                //Console.ReadLine();
            }
        }

        public static string WhatMonthName(int month)
        {
            switch (month)
            {
                case 0: return "\t\t 1월";
                case 1: return "\t\t 2월";
                case 2: return "\t\t 3월";
                case 3: return "\t\t 4월";
                case 4: return "\t\t 5월";
                case 5: return "\t\t 6월";
                case 6: return "\t\t 7월";
                case 7: return "\t\t 8월";
                case 8: return "\t\t 9월";
                case 9: return "\t\t 10월";
                case 10: return "\t\t 11월";
                case 11: return "\t\t 12월";
                default: return "";
            }
        }

        //public static int TotalMonthDays(int year, int month)
        //{
        //    int totalmonthDays;
        //    if (month == 2)
        //    {
        //        if (YunYear(year))
        //        {
        //            totalmonthDays = 29;
        //        }
        //        else
        //        {
        //            totalmonthDays = 28;
        //        }
        //    }
        //    else if (month == 4 || month == 6 || month == 9 || month == 11)
        //    {
        //        totalmonthDays = 30;
        //    }
        //    else
        //    {
        //        totalmonthDays = 31;
        //    }

        //    return totalmonthDays;
        //}

        public static int FirstDayOfMonth(int year, int month, int nowDay)
        {
            int preMonthtotalDays = 0;

            // 전달까지 총일 수를 구한다.
            preMonthtotalDays = PreMonthTotalDays(year, month);

            // 구하는 달 1일의 요일을 구한다.
            int firstDay = (preMonthtotalDays + nowDay) % 7;

            int days = allMonthDays[month];
            if (month == 1 && YunYear(year))
            {
                days++;
            }

            for (int day = 1; day <= days; day++)
            {
                int test = (day + firstDay) % 7;

                if (test == 0)
                {
                    Console.WriteLine();
                }

                if (test == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                if (test == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.Write("\t" + day);
                Console.ResetColor();
            }

            return firstDay;
        }

        public static int PreMonthTotalDays(int year, int month)
        {
            int totalDays = 0;
            int preYear = year - 1;
            totalDays = preYear * 365 + (preYear / 4 + preYear / 400 - preYear / 100);

            return totalDays;
        }

        // 윤년 체크
        public static bool YunYear(int year)
        {
            if ((year % 4 == 0 || year % 400 == 0) && year % 100 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void DisplayCalendar(int year, int month, int startDay)
        {
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.Write("일");
            //Console.ResetColor();
            //Console.Write("\t월\t화\t수\t목\t금\t");
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("토");
            //Console.ResetColor();

            //int days = allMonthDays[month];
            //if (month == 1 && YunYear(year))
            //{
            //    days++;
            //}

            //for (int day =1; day <= days; day++)
            //{
            //    day + firstDay
            //    Console.ForegroundColor = ConsoleColor.White;
            //    if (i == 0)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //    }
            //    if (i == 6)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Blue;
            //    }
            //    Console.Write(dayCounter + "\t");
            //    Console.ResetColor();
            //    dayCounter++;
            //}
            //Console.WriteLine();

            //int remainingDays = totalmonthDays - dayCounter + 1;
            //int rows = remainingDays / 7;
            //int remainingRowDays = remainingDays % 7;

            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < 7; j++)
            //    {
            //        Console.ForegroundColor = ConsoleColor.White;
            //        if (j == 0)
            //        {
            //            Console.ForegroundColor = ConsoleColor.Red;
            //        }
            //        if (j == 6)
            //        {
            //            Console.ForegroundColor = ConsoleColor.Blue;
            //        }
            //    }
            //    Console.ResetColor();
            //}
        }
    }
}
```

![image](https://user-images.githubusercontent.com/102361334/217769156-73216a74-e41f-4fbd-adbb-90cc9f94b2da.png)



