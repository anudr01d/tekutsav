using System;
using System.Threading.Tasks;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.Business.EventVoteSchedule
{
    public interface IEventVoteScheduleServie
    {
        Task<int> CheckIfVotingIsOpen(string eventTypeId);
    }
}
