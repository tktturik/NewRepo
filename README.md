# Угадай число

Программа сама генерирует число на основе следующего алгоритма, который добавляет цифру в строку, если она еще не была добавлена. 

  ````C#
  private string GenerateDigit()
  {
      Random random = new Random();
      string result = "";
      int i = 0;
      while (i < 4) { 
          string digit = random.Next(0, 10).ToString();
          if (!SymbolInDigit(result, digit)) { result += digit; i++; }
      }
      return result;
  }
  private bool SymbolInDigit(string dd, string s)
  {
      foreach(char c in dd)
      {
          if(Convert.ToChar(s) == c)
          {
              return true;
          }
      }
      return false;
  }
    
````
При запуске приложения открывается окно авторизации

![image](https://github.com/user-attachments/assets/28e98de7-5e17-4f16-b585-be7824946dd7)

Логин и пароль проверяется на совпадения с данными, которые считываются с текстового файла

После успешной авторизации открывается окно самой игры

![image](https://github.com/user-attachments/assets/98a45613-689b-4202-a23f-ff1e46d0066a)
