using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	class Program {
		static void Main( string[] args ) {
			int generations = 0;
			Problem problem = new Problem();

			/*
			problem.Cases.Add( new Case( 2, 2, 6.3 - 2 * 0.7 ) );
			problem.Cases.Add( new Case( 1, 2, 2.3 - 1 * 0.7 ) );
			problem.Cases.Add( new Case( 3, 1, 4.3 - 3 * 0.7 ) );
			problem.Cases.Add( new Case( 1, 1, 0.3 - 1 * 0.7 ) );
			problem.Cases.Add( new Case( 10, 10, 198.3 - 10 * 0.7 ) );
			*/
			problem.Cases.Add( new Case( 1, 2, ( 1 * 2 ) + 5 ) ); // 7
			problem.Cases.Add( new Case( 2, 4, ( 2 * 4 ) + 5 ) ); // 13
			problem.Cases.Add( new Case( 6, 6, ( 6 * 6 ) + 5 ) ); // 41
			problem.Cases.Add( new Case( 18, 7, ( 18 * 7 ) + 5 ) ); // 131



			List<Organism> organisms = new List<Organism>();
			for( int i = 0; i < 20; i++ ) {
				Organism organism = new Organism( problem );
				organisms.Add( organism );
			}

			bool done = false;
			double bestError = double.MaxValue;
			double previousError = bestError;
			Organism bestOrganism = null;
			double minError = 0.000000000001;
			double worstError = double.MinValue;
			Organism worstOrganism = null;

			while( done == false ) {
				generations++;
				foreach( Organism organism in organisms ) {
					organism.Tick();

					if( organism.Error < bestError ) {
						bestError = organism.Error;
						bestOrganism = organism;
					}

					if( organism.Error > worstError ) {
						worstError = organism.Error;
						worstOrganism = organism;
					}

					if( organism.Error < minError ) {
						done = true;
						break;
					}

				}


				if( Tool.GetInt( 10 ) == 1 ) {
					organisms.Remove( worstOrganism );
					Organism clone = bestOrganism.Clone();
					organisms.Add( clone );
				} else if( Tool.GetInt( 30 ) == 1 ) {
					organisms.Remove( worstOrganism );
					int index = Tool.GetInt( organisms.Count );
					Organism clone = organisms[ index ].Clone();
					organisms.Add( clone );
				} else if( Tool.GetInt( 100 ) == 1 ) {
					organisms.Remove( worstOrganism );

					int index = Tool.GetInt( organisms.Count );
					Organism mother = bestOrganism;
					Organism father = organisms[ index ];

					Organism child = mother.MakeCrossOver( father );
					organisms.Add( child );
				}


				worstOrganism = null;
				worstError = double.MinValue;

				if( bestError != previousError ) {
					if( bestOrganism != null ) {
						Console.ForegroundColor = ConsoleColor.White;
						if( bestError / previousError < 0.95 )
							Console.ForegroundColor = ConsoleColor.Red;
						else if( bestError / previousError < 0.98 )
							Console.ForegroundColor = ConsoleColor.Yellow;

						Console.WriteLine( "Current Error level {0} - {1}", bestError.ToString( "0.000000000000000" ), bestOrganism.ToString() );
						Console.ForegroundColor = ConsoleColor.White;
					}

					previousError = bestError;
				}

			}

			Console.WriteLine( "Generations: {0}", generations );
			Console.WriteLine();
			Console.WriteLine( "solved..." );
			Console.WriteLine( bestOrganism );
			Console.WriteLine();
			Console.WriteLine( "Proof:" );

			int oldLength = bestOrganism.ToString().Length;
			foreach( Case currentCase in problem.Cases ) {
				double res = bestOrganism.Evaluate( currentCase.X, currentCase.Y );
				Console.WriteLine( "x = {0} , y = {1} , goal = {2} , actual = {3}", currentCase.X, currentCase.Y, currentCase.Result, res );
			}

			bestOrganism.Collapse();
			while( true ) {
				bestOrganism.Tick();
				int l = bestOrganism.ToString().Length;
				if( l < oldLength ) {
					Console.WriteLine( bestOrganism.ToString() );
					oldLength = l;
				}
			}


			Console.ReadLine();
		}
	}
}
