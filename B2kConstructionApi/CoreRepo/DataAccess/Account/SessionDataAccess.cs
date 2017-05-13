using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Data;
using CoreRepo.Data.Account;

namespace CoreRepo.DataAccess.Account
{
    public class SessionDataAccess
    {
        private readonly Context DbContext;
        public SessionDataAccess(Context dbContext)
        {
            DbContext = dbContext;
        }

        public List<Session> GetListOfAllSessions()
        {
            return DbContext.Sessions.Where(sess => sess.IsActive).ToList();
        }

        public List<Session> GetListOfSessionsByUserId(int id)
        {
            return DbContext.Sessions.Where(sess => sess.IsActive && sess.UserId == id).ToList();
        }

        public List<Session> GetListOfSessionsByUserName(string name)
        {
            return DbContext.Sessions.Where(sess => sess.IsActive && sess.User.Name.Contains(name)).ToList();
        }

        public List<Session> GetListOfSessionsByUserEmail(string email)
        {
            return DbContext.Sessions.Where(sess => sess.IsActive && sess.User.Email.Contains(email)).ToList();
        }

        public Session GetSessionById(int id)
        {
            try
            {
                return DbContext.Sessions.First(sess => sess.IsActive && sess.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Session GetSessionByToken(string token)
        {
            try
            {
                return DbContext.Sessions.First(sess => sess.IsActive && sess.Token == token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Session UpdateSession(Session session)
        {
            try
            {
                session.LastEditedDateTime = DateTime.UtcNow;
                DbContext.Sessions.Update(session);
                DbContext.SaveChanges();
                return session;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool DeleteSession(Session session)
        {
            try
            {
                session.LastEditedDateTime = DateTime.UtcNow;
                session.IsActive = false;
                DbContext.Sessions.Update(session);
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

    }
}
