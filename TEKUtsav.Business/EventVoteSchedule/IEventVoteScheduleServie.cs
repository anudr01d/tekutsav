﻿using System.Threading.Tasks;

namespace TEKUtsav.Business.EventVoteSchedule
{
    public interface IEventVoteScheduleServie
    {
        Task<int> CheckIfVotingIsOpen(string eventTypeId);
    }
}
