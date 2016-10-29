using System;

namespace Core.Helpers
{
    public struct SeasonHelper
    {
        private int _seasonId;
        private int _seasonStartYear;
        private int _seasonEndYear;

        public int SeasonId
        {
            get
            {
                if (_seasonId != 0)
                {
                    return _seasonId;
                }

                _seasonId = SeasonStartYear * 10000 + SeasonEndYear;
                return _seasonId;
            }
        }
        public int SeasonStartYear
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
        public int SeasonEndYear
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
    }
}
