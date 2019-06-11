namespace Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }

        public int Count
        {
            get => this.heroes.Count;
        }

        public void Add(Hero hero)
        {
            if (!this.heroes.Any(x => x.Name == hero.Name))
            {
                this.heroes.Add(hero);
            }
        }

        public void Remove(string name)
        {
            if (this.heroes.Any(x => x.Name == name))
            {
                var hero = this.heroes.Find(x => x.Name == name);
                this.heroes.Remove(hero);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            return  this.heroes.OrderByDescending(x => x.Item.Strength).First();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return this.heroes.OrderByDescending(x => x.Item.Ability).First();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return this.heroes.OrderByDescending(x => x.Item.Intelligence).First();
        }

        public override string ToString()
        {
            string result = string.Empty;

            int count = this.heroes.Count;
            foreach (var hero in heroes)
            {
                if (count > 1)
                {
                    result += hero.ToString();
                    result += Environment.NewLine;
                }
                else
                {
                    result += hero.ToString();
                }

                count--;
            }

            return result.ToString();
        }
    }
}
