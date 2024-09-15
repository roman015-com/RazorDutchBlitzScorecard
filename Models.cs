using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorDutchBlitzScorecard
{    
    public class Score
    {
        private int? _total, _dutchCount, _blitzCount;

        public int? Total 
        {
            get
            {
                return _total;
            }
            set
            {
                if (_total != value)
                {
                    _dutchCount = null;
                    _blitzCount = null;
                }
                _total = value;                
            } 
        }
        public int? DutchCount // +1 for each card
        { 
            get
            {
                return _dutchCount;
            }
            set
            {
                _dutchCount = value;
                if (_dutchCount != null && _blitzCount != null)
                {
                    _total = _dutchCount - 2 * _blitzCount;
                }
            }
        } 
        public int? BlitzCount // -2 for each card
        {
            get
            {
                return _blitzCount;
            }
            set
            {
                _blitzCount = value;
                if (_dutchCount != null && _blitzCount != null)
                {
                    _total = _dutchCount - 2 * _blitzCount;
                }
            }
        } 

        public void UpdateTotal()
        {
            if (DutchCount != null && BlitzCount != null)
            {
                Total = DutchCount.Value - (2 * BlitzCount.Value);
            }
        }
    }

    public class Player
    {
        public string Name { get; set; } = "";
        public List<Score> Scores { get; set; } = new List<Score>();        

        public int TotalScore => Scores.Select(score => score.Total ?? 0).Sum();

        public void ResetScore()
        {
            Scores.Clear(); 

            // Leave one score in the list
            Scores.Add(new Score());
        }
    }
}
