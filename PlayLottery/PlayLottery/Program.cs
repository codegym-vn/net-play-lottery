using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayLottery
{
    class Program
    {
        static void Main(string[] args)
        {
            // Khai báo các biến sử dụng trong chương trình
            string lottery, guessDigit1, guessDigit2, firstPrize, secondPrize;

            // Nhập vào số đầu tiên của dự đoán
            Console.Write("Enter the first number: ");
            guessDigit1 = Console.ReadLine();

            // Nhập vào số thứ hai của dự đoán
            Console.Write("Enter the second number: ");
            guessDigit2 = Console.ReadLine();

            firstPrize = String.Concat(guessDigit1, guessDigit2);
            secondPrize = String.Concat(guessDigit2, guessDigit1);

            // Sinh ra số ngẫu nhiên(0 - 99) và lưu vào biến lottery
            lottery = GetRandom(00, 99).ToString();

            // Nếu số ngẫu nhiên nằm trong khoảng (0 - 9), ta thêm số 0 đằng trước, ví dụ "05"
            if (lottery.Trim().Length == 1)
            {
                lottery = "0" + lottery;
            }

            // In ra kết quả xổ số
            Console.WriteLine("Lottery results are: {0}", lottery);

            // Kiểm tra các số nhập vào và hiển thị kết quả xổ số
            if (lottery.Equals(firstPrize))
            {
                Console.Write("Congratulations, the prize is $ 10,000 !");
            }
            else if (lottery.Equals(secondPrize))
            {
                Console.Write("Congratulations, the prize is $ 3,000 !");
            }
            else if (lottery.Contains(guessDigit1) || lottery.Contains(guessDigit2))
            {
                Console.Write("Congratulations, the prize is $ 1,000 !");
            }
            else
            {
                Console.Write("Wish you luck next time !");
            }

            Console.ReadLine();
        }

        // Hàm tạo ra số ngẫu nhiên có 2 chữ số
        private static int GetRandom(int min, int max)
        {
            using (System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[4];
                rng.GetBytes(randomNumber);
                int value = BitConverter.ToInt32(randomNumber, 0);
                return Math.Abs(value % max + min);
            }
        }
    }
}
