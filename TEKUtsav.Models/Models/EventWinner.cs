using TEKUtsav.Models.Entities;

namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class EventWinner : TableData
    {
        public string WinnerCode { get; set; }
        public string Category { get; set; }
        public string Team { get; set; }
        public int Votes { get; set; }
    }
}
