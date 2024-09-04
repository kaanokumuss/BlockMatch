using System;
using System.Collections.Generic;
using Game.Combo;
using UnityEngine;
using Zenject;

namespace Game.Services
{
    public class ComboService
    {
        public static void DoComboExplosion(List<Cell> comboCells, Cell tappedCell, DiContainer diContainer)
        {
            var comboType = CalculateComboType(comboCells);

            switch (comboType)
            {
                case ComboType.None:
                    Debug.LogWarning("Combo type not found");
                    break;
                case ComboType.RocketRocket:
                    var comboRR = new RocketRocketCombo(tappedCell, comboCells);
                    diContainer.Inject(comboRR);
                    comboRR.TryExecute();
                    break;
                case ComboType.BombRocket:
                    var comboBR = new BombRocketCombo(tappedCell, comboCells);
                    diContainer.Inject(comboBR);
                    comboBR.TryExecute();
                    break;
                case ComboType.BombBomb:
                    var comboBB = new BombBomb(tappedCell, comboCells);
                    diContainer.Inject(comboBB);
                    comboBB.TryExecute();
                    break;
                case ComboType.DiscoBomb:
                    var comboDB = new DiscoBomb(tappedCell, comboCells);
                    diContainer.Inject(comboDB);
                    comboDB.TryExecute();
                    break;
                case ComboType.DiscoRocket:
                    var comboDR = new DiscoRocket(tappedCell, comboCells);
                    diContainer.Inject(comboDR);
                    comboDR.TryExecute();
                    break;
                case ComboType.DiscoDisco:
                    var comboDD = new DiscoDisco(tappedCell, comboCells);
                    diContainer.Inject(comboDD);
                    comboDD.TryExecute();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static ComboType CalculateComboType(List<Cell> comboCells)
        {
            var bombAmount = 0;
            var rocketAmount = 0;
            var discoAmount = 0;

            foreach (var cell in comboCells)
            {
                var type = cell.Item.GetSpecialType();
                if (type == SpecialType.Disco)
                {
                    discoAmount++;
                }
                else if(type == SpecialType.Bomb)
                {
                    bombAmount++;
                }
                else if(type == SpecialType.Rocket)
                {
                    rocketAmount++;
                }
            }

            if (discoAmount > 1)
            {
                return ComboType.DiscoDisco;
            }
            if (discoAmount == 1 && bombAmount >= 1)
            {
                return ComboType.DiscoBomb;
            }
            if (discoAmount == 1 && rocketAmount >= 1)
            {
                return ComboType.DiscoRocket;
            }
            if (bombAmount > 1)
            {
                return ComboType.BombBomb;
            }
            if (bombAmount == 1 && rocketAmount >= 1)
            {
                return ComboType.BombRocket;
            }
            if (bombAmount == 0 && rocketAmount > 1)
            {
                return ComboType.RocketRocket;
            }
            
            return ComboType.None;
        }
    }
}