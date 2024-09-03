namespace FreshShop.MvcWebUI.Helpers
{
    public class MailModel
    {
        public string GetMailModel(string fullName, string password)
        {
            return $@"
<div style='font-family: Arial, sans-serif; padding: 20px; border: 1px solid #ddd; border-radius: 10px; max-width: 600px; margin: auto;'>
    <div style='text-align: center; margin-bottom: 20px;'>
        <!-- Resim ve Site Adı -->
        <img src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS_379w_76BTjY4H7gjoRwUVjPEPh5eO0HJNw&s' 
             alt='Site Logosu' 
             style='max-width: 100px; margin-bottom: 10px; border-radius: 50%; border: 5px solid #007BFF;' />
        <h1 style='font-size: 24px; color: #333; margin: 0;'>Fresh <b> Shop</b></h1>
    </div>
    <h2 style='color: #007BFF;'>Merhaba, Sayın {fullName}!</h2>
    <p style='font-size: 16px; color: #333;'>Yeni şifreniz aşağıda belirtilmiştir:</p>
    <p style='font-size: 18px; font-weight: bold; color: #d9534f; background-color: #f8f9fa; padding: 10px; border-radius: 5px; text-align: center;'>
        {password}
    </p>
    <p style='font-size: 14px; color: #555;'>Bu şifreyi kullanarak hesabınıza giriş yapabilirsiniz. Güvenliğiniz için şifrenizi kimseyle paylaşmayınız.</p>
    <p style='font-size: 14px; color: #555;'>İyi günler dileriz.</p>
    <p style='font-size: 14px; color: #007BFF;'>Destek Ekibi</p>
</div>";
        }

    }
}
