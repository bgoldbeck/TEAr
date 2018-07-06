﻿//Copyright(c) 2018 Daniel Bramblett, Daniel Dupriest, Brandon Goldbeck

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecs;
using Game.Interfaces;
using IO;

namespace Game.Components
{
    class GameManager : Component
    {
        public int gameWidth;
        public int gameHeight;

        public GameManager(int width, int height)
        {
            this.gameWidth = width;
            this.gameHeight = height;

        }

        public override void Start()
        {
            GameObject mapObject = GameObject.Instantiate("Map");
            Map map = new Map(gameWidth, gameHeight);
            mapObject.AddComponent(map);
            
            GameObject player = GameObject.Instantiate("Player");
            player.AddComponent(new Player());
            player.AddComponent(new PlayerController());
            player.AddComponent(new Model());
            player.AddComponent(new Collider());
            player.transform.position.x = map.startingX;
            player.transform.position.y = map.startingY;

            Model playerModel = (Model)player.GetComponent(typeof(Model));
            playerModel.model.Add("$");

            Debug.Log("GameManager added all components on start.");
            return;
        }

        public override void Update()
        {
            return;
        }

        public override void Render()
        {
            return;
        }
    }
}
