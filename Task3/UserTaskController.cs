using Task3.DoNotChange;
using Task3.ValidationExceptions;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            try
            {
                string message = GetMessageForModel(userId, description);

                model.AddAttribute("action_result", message);
                return false;
            }
            catch (ResultZeroException)
            {
                return true;
            }
        }

        private string GetMessageForModel(int userId, string description)
        {
            var task = new UserTask(description);
            int result;

            try
            {
                result = _taskService.AddTaskForUser(userId, task);
            }
            catch (ArgumentLessThenZeroException)
            {
                return "Invalid userId";
            }
            catch (ResultNullException)
            {
                return "User not found";
            }
            catch (ArgumentsNotEqualsException)
            {
                return "The task already exists";
            }

            if (result == 0)
            {
                throw new ResultZeroException();
            }

            return string.Empty;
        }
    }
}