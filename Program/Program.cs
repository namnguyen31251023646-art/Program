using System;
using System.Net;
using System.Net.Mail;

namespace ConsoleApp25
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // 1. Cấu hình máy chủ SMTP Gmail
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;

            string senderEmail = "uehktxsmartnet@ueh.edu.vn";
            string senderPassword = "kifbizsvwiykyiuh"; // 16 ký tự Google App Password

            Console.Write("Nhập email người nhận: ");
            string receiverEmail = Console.ReadLine();

            if (string.IsNullOrEmpty(receiverEmail))
            {
                Console.WriteLine("LỖI: Email người nhận không được để trống!");
                return;
            }

            // 2. Thông tin dự án UEH KTX SmartNet
            string projectName = "UEH KTX SmartNet";
            string landingPageUrl = "http://nhom1-smartnet.infinityfreeapp.com";

            try
            {
                // 3. Khởi tạo nội dung Email
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail, "UEH KTX SmartNet Team");
                mail.To.Add(receiverEmail);
                mail.Subject = "[" + projectName + "] Giới thiệu Đồ án Mạng máy tính — UEH";

                // Nội dung Email dạng HTML
                mail.IsBodyHtml = true;
                mail.Body = @"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body { font-family: Arial, sans-serif; line-height: 1.6; color: #0b1220; background-color: #f5f8fc; padding: 20px; }
                        .container { max-width: 600px; margin: 0 auto; background: #ffffff; border: 1px solid #e4eaf3; border-radius: 16px; overflow: hidden; }
                        .header { background: #0b1220; color: #ffffff; padding: 25px; text-align: center; border-bottom: 3px solid #2864f0; }
                        .header h1 { margin: 0; font-size: 20px; color: #22d3ee; }
                        .content { padding: 25px; }
                        .card { background: #f8fafc; border: 1px solid #e2e8f0; border-radius: 10px; padding: 15px; margin: 15px 0; }
                        .btn { display: inline-block; padding: 12px 24px; color: #ffffff !important; background: #2864f0; text-decoration: none; border-radius: 8px; font-weight: bold; }
                        .footer { background: #080e18; color: #64748b; padding: 15px; text-align: center; font-size: 12px; }
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>" + projectName + @"</h1>
                            <p style='margin: 5px 0 0 0; font-size: 12px; color: #94a3b8;'>Đại học UEH · Mạng máy tính</p>
                        </div>
                        <div class='content'>
                            <p>Xin chào,</p>
                            <p>Nhóm trân trọng giới thiệu đồ án <strong>" + projectName + @"</strong> — Hệ thống quản lý truy cập và giám sát mạng Ký túc xá.</p>
                            
                            <div class='card'>
                                <strong style='color: #0369a1;'>VẤN ĐỀ THỰC TIỄN & GIẢI PHÁP</strong>
                                <p style='margin: 5px 0 0 0; font-size: 13px;'>Giải quyết nghẽn mạng giờ cao điểm qua kiến trúc Client–Server, tự động cấp IP (DHCP), phân giải tên miền (DNS), Captive Portal & WebRTC.</p>
                            </div>

                            <div style='text-align: center; margin-top: 20px;'>
                                <a href='" + landingPageUrl + @"' class='btn'>Trải Nghiệm Landing Page Dự Án ↗</a>
                            </div>
                        </div>
                        <div class='footer'>
                            Thư tự động gửi từ ứng dụng C# Console App (SMTP Client).
                        </div>
                    </div>
                </body>
                </html>";

                // 4. Cấu hình SMTP
                SmtpClient smtpClient = new SmtpClient(smtpServer);
                smtpClient.Port = smtpPort;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;

                Console.WriteLine("[*] Đang kết nối tới máy chủ Gmail SMTP...");
                smtpClient.Send(mail);
                Console.WriteLine("\n[SUCCESS] GỬI EMAIL THÀNH CÔNG VỚI C#!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n[ERROR] Không thể gửi email. Chi tiết lỗi: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Chi tiết bên trong: " + ex.InnerException.Message);
                }
            }

            Console.ReadLine();
        }
    }
}