using System;
using System.Linq;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void AddTaskForUser(int userId, UserTask task)
        {
            if (userId < 0)
                throw new InvalidUserIdException("Invalid userId");

            var user = _userDao.GetUser(userId);
            if (user == null)
                throw new UserNotFoundException("User not found");

            if (user.Tasks.Any(t => string.Equals(t.Description, task.Description, StringComparison.OrdinalIgnoreCase)))
                throw new TaskAlreadyExistsException("The task already exists");

            user.Tasks.Add(task);
        }

        public class InvalidUserIdException : ArgumentException
        {
            public InvalidUserIdException(string message) : base(message) { }
        }

        public class UserNotFoundException : Exception
        {
            public UserNotFoundException(string message) : base(message) { }
        }

        public class TaskAlreadyExistsException : Exception
        {
            public TaskAlreadyExistsException(string message) : base(message) { }
        }
    }
}