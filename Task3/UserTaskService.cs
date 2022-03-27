using System;
using Task3.DoNotChange;
using Task3.ValidationExceptions;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public int AddTaskForUser(int userId, UserTask task)
        {
            if (userId < 0)
                throw new ArgumentLessThenZeroException();

            var user = _userDao.GetUser(userId);
            if (user == null)
                throw new ResultNullException();

            var tasks = user.Tasks;
            foreach (var t in tasks)
            {
                if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentsNotEqualsException();
            }

            tasks.Add(task);

            return 0;
        }
    }
}