using System;

namespace Core.Helpers
{
    public struct SeasonHelper
    {
        private int _seasonId;
        private int _seasonStartYear;
        private int _seasonEndYear;

        public int CurrentSeasonId
        {
            get
            {
                if (_seasonId != 0)
                {
                    return _seasonId;
                }

                _seasonId = CurrentSeasonStartYear * 10000 + CurrentSeasonEndYear;
                return _seasonId;
            }
        }
        public int CurrentSeasonStartYear
        {
            get
            {
                if (_seasonStartYear != 0)
                {
                    return _seasonStartYear;
                }
                DateTime date = DateTime.Now;
                int year = date.Year;
                int month = date.Month;

                if (month >= 9)
                {
                    _seasonStartYear = year;
                    return _seasonStartYear;
                }
                else
                {
                    _seasonStartYear = year - 1;
                    return _seasonStartYear;
                }
            }
        }
        public int CurrentSeasonEndYear
        {
            get
            {
                if (_seasonEndYear != 0)
                {
                    return _seasonEndYear;
                }
                DateTime date = DateTime.Now;
                int year = date.Year;
                int month = date.Month;

                if (month >= 9)
                {
                    _seasonEndYear = year + 1;
                    return _seasonEndYear;
                }
                else
                {
                    _seasonEndYear = year;
                    return _seasonEndYear;
                }
            }
        }

        public static int GetSeasonId(int startYear, int endYear)
        {
            if (endYear - startYear != 1)
                throw new ArgumentException("Not valid values of inpur years");
            return startYear * 10000 + endYear;
        }

        public static int GetSeasonId(string startYear, string endYear)
        {
            int start = 0;
            int end = 0;
            bool isSuccessParseDates = int.TryParse(startYear, out start) && int.TryParse(endYear, out end);
            if (!isSuccessParseDates || end - start != 1)
                throw new ArgumentException("Not valid values of inpur years");

            return start * 10000 + end;
        }
    }
}
