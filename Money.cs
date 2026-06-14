using System;

namespace OperatorApp
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public Money(decimal amount, string currency)
        {
            if (amount < 0)
                throw new ArgumentException("So tien khong the am!");
            Amount = amount;
            Currency = currency.ToUpper();
        }

        // Ham kiem tra cung don vi – dung lai trong nhieu toan tu
        private static void KiemTraCungDonVi(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException(
                    $"Khong the thuc hien phep toan giua {a.Currency} va {b.Currency}. " +
                    $"Vui long quy doi ve cung don vi truoc.");
        }

        public static Money operator +(Money a, Money b)
        {
            KiemTraCungDonVi(a, b);
            return new Money(a.Amount + b.Amount, a.Currency);
        }

        public static Money operator -(Money a, Money b)
        {
            KiemTraCungDonVi(a, b);
            if (a.Amount < b.Amount)
                throw new InvalidOperationException("Ket qua tru khong duoc am!");
            return new Money(a.Amount - b.Amount, a.Currency);
        }

        // Nhan voi he so (vi du: tinh luong lam them gio)
        public static Money operator *(Money m, decimal heSo)
        {
            if (heSo < 0)
                throw new ArgumentException("He so khong the am!");
            return new Money(m.Amount * heSo, m.Currency);
        }

        public static Money operator *(decimal heSo, Money m) => m * heSo;

        public static bool operator >(Money a, Money b)
        {
            KiemTraCungDonVi(a, b);
            return a.Amount > b.Amount;
        }

        public static bool operator <(Money a, Money b)
        {
            KiemTraCungDonVi(a, b);
            return a.Amount < b.Amount;
        }

        public override string ToString()
            => $"{Amount:N0} {Currency}";
        /// này chưa hay lắm
        public static Money QuyDoi(Money nguon, string donViDich,decimal tygia)
        {
            return new Money(nguon.Amount * tygia, donViDich);
        }
        /// nếu làm thì em nghĩ sẽ làm kiểu này
        public static Money QuyDoi2(Money nguon, string input, string output)
        {

            // api đến các kênh có tỷ giá và lưu lại theo ngày ở hệ thống để dùng
            var tyGias = new Dictionary<DateTime, Dictionary<string, decimal>>
            {
                [new DateTime(2026, 6, 12)] = new()
                {
                    ["USD"] = 1m,
                    ["VND"] = 25000m,
                    ["TWD"] = 29.5m
                },
                [new DateTime(2026, 6, 13)] = new()
                {
                    ["USD"] = 1m,
                    ["VND"] = 25100m,
                    ["TWD"] = 29.8m
                }
            };
            /// lấy ngày hiện tại để check tỷ giá nếu ko có thì lấy ngày cuối cùng
            DateTime ngay = DateTime.Today;
            if (!tyGias.ContainsKey(ngay))
                ngay = tyGias.Keys.Max();
            decimal tyGiaNguon = tyGias[ngay][input];
            decimal tyGiaDich = tyGias[ngay][output];
            decimal amount = nguon.Amount / tyGiaNguon * tyGiaDich;
            return new Money(amount, output);
        }

        private static bool check(Money a, Money b)
               => a.Currency == b.Currency?true:false;
        public static bool operator ==(Money a, Money b)
            => check(a, b)&&a.Amount==b.Amount;
        public static bool operator !=(Money a, Money b)
            => !(a == b);

        public static Money operator /(Money money, int soNguoi)
        {
            if (soNguoi <= 0)
                throw new DivideByZeroException();
            return new Money(
                money.Amount / soNguoi,
                money.Currency
            );
        }
    }

}
