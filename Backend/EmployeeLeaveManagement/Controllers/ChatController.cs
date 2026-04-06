using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        [HttpPost("message")]
        public IActionResult ProcessMessage([FromBody] ChatRequest request)
        {
            string msg = request.Message.ToLower();

            // Intent 1: Apply for Leave
            if (msg.Contains("plan leave") || msg.Contains("apply leave") || msg.Contains("take off"))
            {
                return Ok(new
                {
                    botReply = "I can help with that! Please select your dates and leave type below:",
                    actionRequired = "SHOW_CALENDAR"
                });
            }

            // Intent 2: Check Balances
            if (msg.Contains("balance") || msg.Contains("how many days"))
            {
                return Ok(new
                {
                    botReply = "Let me check that for you. Pulling up your balances now...",
                    actionRequired = "FETCH_BALANCES"
                });
            }

            // Fallback: Doesn't understand
            return Ok(new
            {
                botReply = "I'm still learning! Try asking me to 'plan leave' or 'check balances'.",
                actionRequired = "NONE"
            });
        }
        public class ChatRequest
        {
            public string AssociateId { get; set; } = string.Empty;
            public string Message { get; set; } = string.Empty;
        }
    }
}
