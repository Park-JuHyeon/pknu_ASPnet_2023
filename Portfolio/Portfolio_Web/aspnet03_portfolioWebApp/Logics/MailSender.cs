using MimeKit;
using System.Text;

namespace aspnet03_portfolioWebApp.Logics
{
    public class MailSender
    {
        // toMail: 보내고자하는 이메일주소
        // title: 보내고자하는 이메일의 제목
        // mailContent : 보내고자하는 이메일의 내용(HTML 태그형식의 string 값)
        public static void SendMail(string fromMail, string name, string phonenumber, string title, string mailContent)
        {
            var toMail = "j-hyeon97@naver.com";

            if (toMail.IndexOf("@") > -1)
            {
                string id = (toMail.Split('@')[0]).ToString();
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    // 사용하고자하는 email의 smtps 주소, 포트를 입력합니다.
                    client.Connect("smtp.naver.com", 465);
                    // 당신의 아이디와 비밀번호를 입력합니다.
                    client.Authenticate("j-hyeon97", "###");

                    var message = new MimeMessage();
                    //받는사람이 보는
                    // 보내는 사람의 대표이름과 보내는 사람 이메일을 설정합니다.
                    message.From.Add(new MailboxAddress(Encoding.UTF8, id, toMail));
                    message.To.Add(new MailboxAddress(id, toMail));

                    message.Subject = $"{fromMail}로 부터 온 메시지입니다";

                    var builder = new BodyBuilder();

                    builder.HtmlBody += $"{name} / {fromMail}<br>";
                    builder.HtmlBody += mailContent + "<br>";
                    builder.HtmlBody += $"연락처 : {phonenumber}";

                    message.Body = builder.ToMessageBody();
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
        }
    }
}
