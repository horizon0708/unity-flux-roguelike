using System.Collections.Generic;

namespace MyRogueLike.rules
{
    public class RuleManager: IUpdater
    {
        public List<IRule> Rules;
        private GeneralManager _gm;

        public RuleManager(GeneralManager gm)
        {
            Rules = new List<IRule>();
        }

        public void AddRule(IRule rule)
        {
            Rules.Add(rule);
        }

        public void ManageUpdate()
        {
            foreach (var rule in Rules)
            {
                rule.GameUpdate();
            }
        }
    }
}