using System;
using System.Diagnostics;
using Urho;
using Urho.Actions;
using Urho.Gui;
using Urho.Shapes;

namespace GameTest
{
    public class MyGame : Application
    {
        Node cameraNode;
        Node earthNode;
        Node rootNode;
        Scene scene;
        float yaw, pitch;

        [Preserve]
        public MyGame(ApplicationOptions options) : base(options) { }

        static MyGame()
        {
            UnhandledException += (s, e) =>
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                e.Handled = true;
            };
        }

        protected override async void Start()
        {
            HelloWorld();
        }
        
        async void HelloWorld()
        {
            //Criação do texto - o texto é adicionado à UI
            var helloText = new Text()
            {
                Value = "Hello World from MySample",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            helloText.SetColor(new Color(0f, 1f, 1f));
            helloText.SetFont(
                font: ResourceCache.GetFont("Fonts/OLDENGL.TTF"),
                size: 30);
            UI.Root.AddChild(helloText);
        }

        protected override void OnUpdate(float timeStep)
        {

            base.OnUpdate(timeStep);
        }


    }
}
