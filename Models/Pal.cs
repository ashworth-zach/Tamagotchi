using System;
namespace dojodachi.Models
{
    public class Pal
    {
        public int happiness{get;set;}
        public int fullness{get;set;}
        public int energy{get;set;}
        public int meals{get;set;}
        public string status{get;set;}
        public Pal()
        {
            happiness=20;
            fullness=20;
            meals=3;
            energy=50;
            status="Your pal says hello";
        }
        public void feed(){
            Random rand = new Random();
            if(meals==0){
                status="you have no meals to feed your pal :(";
            }
            else{
                meals-=1;
                if(rand.Next(1,5)==2){
                    status="your pal didnt like the food you gave him.";
                }
                else{
                    status="you fed your Pal ";
                    fullness+=rand.Next(5,11);
                }
            }
        }
        public void play(){
            Random rand = new Random();

            if(energy>=5){
                energy-=5;
                if(rand.Next(1,5)==2){
                    status="your pal didnt like that. :/";
                }
                else{
                    happiness+=rand.Next(5,11);
                    status="you play with your pal";
                }
            }
            else{
                status="your pal is out of energy...";
            }
        }
        public void work(){
            Random rand = new Random();

            if(energy>=5){
                energy-=5;
                meals+=rand.Next(1,4);
                status="your pal worked";
            }
            else{
                status="your pal is out of energy...";
            }
        }
        public void sleep(){
            energy+=15;
            fullness-=5;
            happiness-=5;
            status="your pal is sleeping";
        }
    }
}