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
        Node CameraNode;
        Camera camera;
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
            Log.LogMessage += e => Debug.WriteLine($"[{e.Level}] {e.Message}");
            base.Start();
            //HelloWorld("Teste cubo");
            UseMyCube();
        }

        async void UseMyCube()
        {
            var cache = this.ResourceCache;
            //cria a cena
            scene = new Scene(this.Context);
            scene.CreateComponent<Octree>();
            ////cria o node do plano
            //var planeNode = scene.CreateChild("Plane");
            //planeNode.Scale = new Vector3(100, 1, 100);
            //var planeObject = planeNode.CreateComponent<StaticModel>();
            //planeObject.Model = cache.GetModel("Models/Plane.mdl");
            //planeObject.SetMaterial(cache.GetMaterial("Materials/Material.003.xml"));


            //cria o node do cubo
            var cubeNode = scene.CreateChild("Cube");
            cubeNode.Position = new Vector3(0, 1, 10);
            var cubeObject = cubeNode.CreateComponent<StaticModel>();
            cubeObject.Model = cache.GetModel("Models/MyCube.mdl");
            cubeObject.SetMaterial(cache.GetMaterial("Materials/Material _25.xml"));

            //cria o node da luz
            var lightNode = scene.CreateChild("DirectionalLight");
            lightNode.SetDirection(new Vector3(0.6f, -1.0f, 0.8f)); // The direction vector does not need to be normalized
            var light = lightNode.CreateComponent<Light>();
            light.LightType = LightType.Directional;
            //cria o node da câmera
            CameraNode = scene.CreateChild ("camera");
			camera = CameraNode.CreateComponent<Camera>();
			CameraNode.Position = new Vector3(0, 5, -100);
            //Com isso eu tenho uma luz, uma camera e um objeto qqer pendurados na cena

            // Viewport
            var viewport = new Viewport(Context, scene, camera, null);
            viewport.SetClearColor(Color.Yellow);
            Renderer.SetViewport(0, viewport);

        }

        async void HelloWorld(string msg)
        {
            //Criação do texto - o texto é adicionado à UI
            var helloText = new Text()
            {
                Value = msg,
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
