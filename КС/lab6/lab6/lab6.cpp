#include <iostream>
#include <intsafe.h>

using namespace std;
bool CheckAddress(char* ip_)
{
    int points = 0, // количество точек
     numbers = 0; // значение октета
    char* buff; // буфер для одного октета
    buff = new char[3];
    for (int i = 0; ip_[i] != '\0'; i++)
    { // для строки IP-адреса
        if (ip_[i] <= '9' && ip_[i] >= '0') // если цифра
        {
            if (numbers > 3) return false;
            //если больше трех чисел в октете – ошибка
            buff[numbers++] = ip_[i];
            //скопировать в буфер
        }
        else
            if (ip_[i] == '.') // если точка
            {
                if (atoi(buff) > 255)
                    // проверить диапазон октета
                    return false;
                if (numbers == 0)
                    //если числа нет - ошибка
                    return false;
                numbers = 0;
                points++;
                delete[]buff;
                buff = new char[3];
            }
            else return false;
    }
    if (points != 3)
        // если количество точек в IP-адресе не 3 - ошибка
        return false;
    if (numbers == 0 || numbers > 3)
        return false;
    return true;
}

unsigned long CharToLong(char* ip_)
{
    unsigned long out = 0;//число для IP-адреса
    char* buff;
    buff = new char[3];
    //буфер для хранения одного октета
    for (int i = 0, j = 0, k = 0; ip_[i] != '\0'; i++, j++)
    {
        if (ip_[i] != '.') //если не точка
            buff[j] = ip_[i]; // записать символ в буфер
        if (ip_[i] == '.' || ip_[i + 1] == '\0')
        {
            // если следующий октет или последний
            out <<= 8; //сдвинуть число на 8 бит
            if (atoi(buff) > 255)
                return NULL;
            // еcли октет больше 255 – ошибка
            out += (unsigned long)atoi(buff);
            //преобразовать и добавить
            //к числу IP-адреса
            k++;
            j = -1;
            delete[]buff;
            buff = new char[3];
        }
    }
    return out;
}

unsigned long LongtoChar(unsigned long ip_)
{
    return 0;
}

unsigned long CheckMask(char* ip_)
{
    int points = 0, // количество точек
        numbers = 0; // значение октета
    char* buff; // буфер для одного октета
    buff = new char[3];
    for (int i = 0; ip_[i] != '\0'; i++)
    { // для строки IP-адреса
        if (ip_[i] <= '9' && ip_[i] >= '0') // если цифра
        {
            if (numbers > 3) return false;
            //если больше трех чисел в октете – ошибка
            buff[numbers++] = ip_[i];
            //скопировать в буфер
        }
        else
            if (ip_[i] == '.') // если точка
            {
                if (atoi(buff) > 255)
                    // проверить диапазон октета
                    return false;
                if (numbers == 0)
                    //если числа нет - ошибка
                    return false;
                numbers = 0;
                points++;
                delete[]buff;
                buff = new char[3];
            }
            else return false;
    }
    if (points != 3)
        // если количество точек в IP-адресе не 3 - ошибка
        return false;
    if (numbers == 0 || numbers > 3)
        return false;
    return true;
}

int main()
{
    setlocale(LC_ALL, "Russian");

    unsigned long ip, mask, host, subnet, broadcast;
    char* ip_, * mask_;
    bool flag = true;
    ip_ = new char[16];
    mask_ = new char[16];
    do
    {
        if (!flag) cout << "Неверно введён адрес!" << endl;
        cout << "IP: ";
        cin >> ip_;
    } while (!(flag = CheckAddress(ip_)));
    ip = CharToLong(ip_);
    flag = true;
    do
    {
        if (!flag) cout << "Неправильная маска!" << endl;
        flag = true;
        do
        {
            if (!flag) cout << "Неверно введена маска!" << endl;
            cout << "Маска: ";
            cin >> mask_;
        } while (!(flag = CheckAddress(mask_)));
        mask = CharToLong(mask_);
    } while (!(flag = CheckMask(mask_)));


    subnet = ip & mask;
    broadcast = ip & mask | ~mask;
    host = ip & ~mask;
    cout << ULongToChar(subnet,ip_) << endl;
    cout << broadcast << endl;
    cout << host << endl;
}
