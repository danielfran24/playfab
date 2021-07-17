using PlayFab.ClientModels;
using System;
using System.Collections.Generic;

namespace ClasePlayfab {


    [Serializable]
    public class PlayerModel {

        public int Money;

        public int TotalHP;

        public int MaxScore;


        private void SetMoney(string money) {

            Money = int.Parse(money);

        }


        private void SetTotalHP(string totalhp) {

            TotalHP = int.Parse(totalhp);

        }

        private void SetMaxScore(string maxscore) {

            MaxScore = int.Parse(maxscore);

        }


        public static PlayerModel LoadPlayerData(Dictionary<string, UserDataRecord> data) {

            PlayerModel model = new PlayerModel();

            model.SetMoney(data["Money"].Value);
            model.SetTotalHP(data["TotalHP"].Value);
            model.SetMaxScore(data["MaxScore"].Value);

            return model;


        }

    }

}