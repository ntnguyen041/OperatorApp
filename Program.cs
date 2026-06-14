namespace OperatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector2D v1 = new Vector2D(3, 4);
            Vector2D v2 = new Vector2D(1, 2);

            Console.WriteLine($"v1 = {v1}");             // (3.00, 4.00)
            Console.WriteLine($"v2 = {v2}");             // (1.00, 2.00)
            Console.WriteLine($"v1 + v2 = {v1 + v2}");  // (4.00, 6.00)
            Console.WriteLine($"v1 - v2 = {v1 - v2}");  // (2.00, 2.00)
            Console.WriteLine($"v1 * 2  = {v1 * 2}");   // (6.00, 8.00)
            Console.WriteLine($"3 * v2  = {3 * v2}");   // (3.00, 6.00)
            Console.WriteLine($"-v1    = {-v1}");        // (-3.00, -4.00)
            Console.WriteLine($"|v1|   = {v1.DoDai:F4}"); // 5.0000


            /////////////////////// bai 2
            Money luong = new Money(15_000_000, "VND");
            Money thuong = new Money(3_000_000, "VND");
            Money lamThemGio = luong * 1.5m;  // Luong lam them = 1.5x luong

            Console.WriteLine($"Luong co ban:   {luong}");
            Console.WriteLine($"Thuong thang:   {thuong}");
            Console.WriteLine($"Luong lam them: {lamThemGio}");
            Console.WriteLine($"Tong thu nhap:  {luong + thuong}");
            Console.WriteLine($"Luong > Thuong: {luong > thuong}");  // True

            // Kiem tra bep logic – khac don vi
            try
            {
                Money usd = new Money(100, "USD");
                Money tong = luong + usd;  // Nem ngoai le!
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
                // In: Loi: Khong the thuc hien phep toan giua VND va USD...
            }
            Console.WriteLine("----------------------------");
            Money sotien = new Money(100, "USD");
            Console.WriteLine(Money.QuyDoi(sotien, "VND",26_000));


            Console.WriteLine("----------------------------");
            Money tongHoaDon = new Money(1000000m, "VND");
            Console.WriteLine(Money.QuyDoi2(tongHoaDon, tongHoaDon.Currency, "USD"));

            Money phanCua1Nguoi = tongHoaDon / 4;
            Console.WriteLine(phanCua1Nguoi.Amount);

        }
    }
}
