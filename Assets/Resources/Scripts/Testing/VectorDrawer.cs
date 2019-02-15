﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.VectorGraphics;
using System.IO;

public class VectorGenerator : MonoBehaviour {
    public Vector2[] Points = new Vector2[7];

    private Scene scene;
    private Shape path;
    private VectorUtils.TessellationOptions options;
    private Mesh mesh;

    private void Start()
    {
        /*
        path = new Shape()
        {
            Contours = new BezierContour[] { new BezierContour() { Segments = new BezierPathSegment[3] } },
            PathProps = new PathProperties()
            {
                Stroke = new Stroke() { Color = Color.white, HalfThickness = 0.1f }
            }
        };

        scene = new Scene()
        {
            Root = new SceneNode() { Shapes = new List<Shape> { path } }
        };

        options = new VectorUtils.TessellationOptions()
        {
            StepDistance = 100.0f,
            MaxCordDeviation = 0.05f,
            MaxTanAngleDeviation = 0.05f,
            SamplingStepSize = 0.01f
        };

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        */
        path = new Shape();
        VectorUtils.MakeCircleShape(path, Vector2.zero, 5.0f);
        path.Fill = new SolidFill() { Color = Color.red };
        path.PathProps = new PathProperties()
        {
            Stroke = new Stroke() { Color = Color.black }
        };

        scene = new Scene()
        {
            Root = new SceneNode() { Shapes = new List<Shape> { path } }
        };

        options = new VectorUtils.TessellationOptions()
        {
            StepDistance = 1.0f,
            MaxCordDeviation = float.MaxValue,
            MaxTanAngleDeviation = Mathf.PI / 2.0f,
            SamplingStepSize = 0.01f
        };

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        /*
        string svg =
            @"<svg width=""283.9"" height=""283.9"" xmlns=""http://www.w3.org/2000/svg"">
                <line x1=""170.3"" y1=""226.99"" x2=""177.38"" y2=""198.64"" fill=""none"" stroke=""#888"" stroke-width=""1""/>
                <line x1=""205.73"" y1=""198.64"" x2=""212.81"" y2=""226.99"" fill=""none"" stroke=""#888"" stroke-width=""1""/>
                <line x1=""212.81"" y1=""226.99"" x2=""219.9"" y2=""255.33"" fill=""none"" stroke=""#888"" stroke-width=""1""/>
                <line x1=""248.25"" y1=""255.33"" x2=""255.33"" y2=""226.99"" fill=""none"" stroke=""#888"" stroke-width=""1""/>
                <path d=""M170.08,226.77c7.09-28.34,35.43-28.34,42.52,0s35.43,28.35,42.52,0"" transform=""translate(0.22 0.22)"" fill=""none"" stroke=""red"" stroke-width=""1.2""/>
                <circle cx=""170.3"" cy=""226.99"" r=""1.2"" fill=""blue"" stroke-width=""0.6""/>
                <circle cx=""212.81"" cy=""226.99"" r=""1.2"" fill=""blue"" stroke-width=""0.6""/>
                <circle cx=""255.33"" cy=""226.99"" r=""1.2"" fill=""blue"" stroke-width=""0.6""/>
                <circle cx=""177.38"" cy=""198.64"" r=""1"" fill=""black"" />
                <circle cx=""205.73"" cy=""198.64"" r=""1"" fill=""black"" />
                <circle cx=""248.25"" cy=""255.33"" r=""1"" fill=""black"" />
                <circle cx=""219.9"" cy=""255.33"" r=""1"" fill=""black"" />
            </svg>";

        var tessOptions = new VectorUtils.TessellationOptions()
        {
            StepDistance = 100.0f,
            MaxCordDeviation = 0.5f,
            MaxTanAngleDeviation = 0.1f,
            SamplingStepSize = 0.01f
        };

        // Dynamically import the SVG data, and tessellate the resulting vector scene.
        var sceneInfo = SVGParser.ImportSVG(new StringReader(svg));
        var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);

        // Build a sprite with the tessellated geometry.
        var sprite = VectorUtils.BuildSprite(geoms, 10.0f, VectorUtils.Alignment.Center, Vector2.zero, 128, true);
        GetComponent<SpriteRenderer>().sprite = sprite;
        */
    }

    private void Update()
    {
        if (scene == null)
        {
            Start();
        }

        //path.Contours[0].Segments[0].P0 = (Vector2)Points[0];
        //path.Contours[0].Segments[0].P1 = (Vector2)Points[1];
        //path.Contours[0].Segments[0].P2 = (Vector2)Points[2];
        //path.Contours[0].Segments[1].P0 = (Vector2)Points[3];
        //path.Contours[0].Segments[1].P1 = (Vector2)Points[4];
        //path.Contours[0].Segments[1].P2 = (Vector2)Points[5];
        //path.Contours[0].Segments[2].P0 = (Vector2)Points[6];

        var geoms = VectorUtils.TessellateScene(scene, options);
        VectorUtils.FillMesh(mesh, geoms, 1.0f);
    }
}
