﻿using System.Collections.Generic;
using QuickGraph;
using QuickGraph.Algorithms;
using System.Windows;
using Unity.Mathematics;
using static Unity.Mathematics.math;

namespace GraphSharp.Algorithms.EdgeRouting
{
	public abstract class EdgeRoutingAlgorithmBase<TVertex, TEdge, TGraph> : AlgorithmBase<TGraph>, IEdgeRoutingAlgorithm<TVertex, TEdge, TGraph>
		where TVertex : class
		where TEdge : IEdge<TVertex>
		where TGraph : IVertexAndEdgeListGraph<TVertex, TEdge>
	{
		protected IDictionary<TVertex, float2> vertexPositions;

		/// <summary>
		/// Gets or sets the routing points of the edges.
		/// </summary>
		public IDictionary<TEdge, float2[]> EdgeRoutes
		{
			get;
			private set;
		}

		public EdgeRoutingAlgorithmBase(TGraph visitedGraph, IDictionary<TVertex, float2> vertexPositions) 
			: base(visitedGraph)
		{
			this.vertexPositions = vertexPositions;
		}
	}
}