
using Models.Outils;

De de = new De();
de.Max = 5;


Lancer(int Max)
{
    Random random = new Random();
    int result = random.share.next(Max) + 1;
}