using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Data;
using CoreRepo.Data.Work;

namespace CoreRepo.DataAccess.Work
{
    public class WorkSessionDataAccess
    {
        private readonly Context DbContext;
        public WorkSessionDataAccess(Context dbContext)
        {
            DbContext = dbContext;
        }

        public List<WorkSession> GetListOfAllWorkSessions()
        {
            return DbContext.WorkSessions.Where(workSess => workSess.IsActive).ToList();
        }

        public List<WorkSession> GetListOfWorkSessionByOrderId(int id)
        {
            return DbContext.WorkSessions.Where(workSess => workSess.IsActive && workSess.OrderId == id).ToList();
        }

        public List<WorkSession> GetListOfWorkSessionByEmployeeId(int id)
        {
            return DbContext.WorkSessions.Where(workSess => workSess.IsActive && workSess.EmployeeId == id).ToList();
        }

        public WorkSession GetWorkSessionById(int id)
        {
            try
            {
                return DbContext.WorkSessions.First(workSess => workSess.IsActive && workSess.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public WorkSession UpdatetWorkSession(WorkSession workSession)
        {
            try
            {
                workSession.LastEditedDateTime = DateTime.UtcNow;
                DbContext.WorkSessions.Update(workSession);
                DbContext.SaveChanges();
                return workSession;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public WorkSession DeleteWorkSession(WorkSession workSession)
        {
            try
            {
                workSession.LastEditedDateTime = DateTime.UtcNow;
                workSession.IsActive = false;
                DbContext.WorkSessions.Update(workSession);
                DbContext.SaveChanges();
                return workSession;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
