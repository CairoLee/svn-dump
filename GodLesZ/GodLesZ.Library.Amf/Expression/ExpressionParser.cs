// $ANTLR 2.7.6 (2005-12-22): "selector.g" -> "ExpressionParser.cs"$

namespace GodLesZ.Library.Amf.Expression {
	// Generate the header common to all output files.
	using System;
	using AST = antlr.collections.AST;
	using ASTFactory = antlr.ASTFactory;
	using ASTPair = antlr.ASTPair;
	using BitSet = antlr.collections.impl.BitSet;
	using NoViableAltException = antlr.NoViableAltException;
	using ParserSharedInputState = antlr.ParserSharedInputState;
	using RecognitionException = antlr.RecognitionException;
	using Token = antlr.Token;
	using TokenBuffer = antlr.TokenBuffer;
	using TokenStream = antlr.TokenStream;

	internal class ExpressionParser : antlr.LLkParser {
		public const int EOF = 1;
		public const int NULL_TREE_LOOKAHEAD = 3;
		public const int EXPR = 4;
		public const int OPERAND = 5;
		public const int FALSE = 6;
		public const int TRUE = 7;
		public const int AND = 8;
		public const int OR = 9;
		public const int NOT = 10;
		public const int IN = 11;
		public const int IS = 12;
		public const int BETWEEN = 13;
		public const int LIKE = 14;
		public const int NULL_LITERAL = 15;
		public const int PLUS = 16;
		public const int MINUS = 17;
		public const int STAR = 18;
		public const int DIV = 19;
		public const int MOD = 20;
		public const int POWER = 21;
		public const int LPAREN = 22;
		public const int RPAREN = 23;
		public const int POUND = 24;
		public const int ID = 25;
		public const int COMMA = 26;
		public const int INTEGER_LITERAL = 27;
		public const int HEXADECIMAL_INTEGER_LITERAL = 28;
		public const int REAL_LITERAL = 29;
		public const int STRING_LITERAL = 30;
		public const int LITERAL_date = 31;
		public const int EQUAL = 32;
		public const int NOT_EQUAL = 33;
		public const int LESS_THAN = 34;
		public const int LESS_THAN_OR_EQUAL = 35;
		public const int GREATER_THAN = 36;
		public const int GREATER_THAN_OR_EQUAL = 37;
		public const int WS = 38;
		public const int AT = 39;
		public const int QMARK = 40;
		public const int DOLLAR = 41;
		public const int LBRACKET = 42;
		public const int RBRACKET = 43;
		public const int LCURLY = 44;
		public const int RCURLY = 45;
		public const int SEMI = 46;
		public const int COLON = 47;
		public const int DOT_ESCAPED = 48;
		public const int APOS = 49;
		public const int NUMERIC_LITERAL = 50;
		public const int DECIMAL_DIGIT = 51;
		public const int INTEGER_TYPE_SUFFIX = 52;
		public const int HEX_DIGIT = 53;
		public const int EXPONENT_PART = 54;
		public const int SIGN = 55;
		public const int REAL_TYPE_SUFFIX = 56;


		public override void reportError(RecognitionException ex) {
			//base.reportError(ex);
			throw ex;
		}

		public override void reportError(string error) {
			//base.reportError(error);
			throw new RecognitionException(error);
		}

		private string GetRelationalOperatorNodeType(string op) {
			switch (op.ToLower()) {
				case "=":
					return "GodLesZ.Library.Amf.Expression.OpEqual";
				case "<>":
					return "GodLesZ.Library.Amf.Expression.OpNotEqual";
				case "<":
					return "GodLesZ.Library.Amf.Expression.OpLess";
				case "<=":
					return "GodLesZ.Library.Amf.Expression.OpLessOrEqual";
				case ">":
					return "GodLesZ.Library.Amf.Expression.OpGreater";
				case ">=":
					return "GodLesZ.Library.Amf.Expression.OpGreaterOrEqual";
				case "in":
					return "GodLesZ.Library.Amf.Expression.OpIn";
				case "is":
					return "GodLesZ.Library.Amf.Expression.OpIs";
				case "between":
					return "GodLesZ.Library.Amf.Expression.OpBetween";
				case "like":
					return "GodLesZ.Library.Amf.Expression.OpLike";
				default:
					throw new ArgumentException("Node type for operator '" + op + "' is not defined.");
			}
		}

		protected void initialize() {
			tokenNames = tokenNames_;
			initializeFactory();
		}


		protected ExpressionParser(TokenBuffer tokenBuf, int k)
			: base(tokenBuf, k) {
			initialize();
		}

		public ExpressionParser(TokenBuffer tokenBuf)
			: this(tokenBuf, 2) {
		}

		protected ExpressionParser(TokenStream lexer, int k)
			: base(lexer, k) {
			initialize();
		}

		public ExpressionParser(TokenStream lexer)
			: this(lexer, 2) {
		}

		public ExpressionParser(ParserSharedInputState state)
			: base(state, 2) {
			initialize();
		}

		public void expr() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST expr_AST = null;

			try {      // for error handling
				expression();
				if (0 == inputState.guessing) {
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				match(Token.EOF_TYPE);
				expr_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_0_);
				} else {
					throw ex;
				}
			}
			returnAST = expr_AST;
		}

		public void expression() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST expression_AST = null;

			try {      // for error handling
				logicalOrExpression();
				if (0 == inputState.guessing) {
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				expression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_1_);
				} else {
					throw ex;
				}
			}
			returnAST = expression_AST;
		}

		public void logicalOrExpression() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST logicalOrExpression_AST = null;

			try {      // for error handling
				logicalAndExpression();
				if (0 == inputState.guessing) {
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				{    // ( ... )*
					for (; ; ) {
						if ((LA(1) == OR)) {
							GodLesZ.Library.Amf.Expression.OpOR tmp2_AST = null;
							tmp2_AST = (GodLesZ.Library.Amf.Expression.OpOR)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.OpOR");
							astFactory.makeASTRoot(ref currentAST, (AST)tmp2_AST);
							match(OR);
							logicalAndExpression();
							if (0 == inputState.guessing) {
								astFactory.addASTChild(ref currentAST, (AST)returnAST);
							}
						} else {
							goto _loop5_breakloop;
						}

					}
				_loop5_breakloop:
					;
				}    // ( ... )*
				logicalOrExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_1_);
				} else {
					throw ex;
				}
			}
			returnAST = logicalOrExpression_AST;
		}

		public void logicalAndExpression() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST logicalAndExpression_AST = null;

			try {      // for error handling
				relationalExpression();
				if (0 == inputState.guessing) {
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				{    // ( ... )*
					for (; ; ) {
						if ((LA(1) == AND)) {
							GodLesZ.Library.Amf.Expression.OpAND tmp3_AST = null;
							tmp3_AST = (GodLesZ.Library.Amf.Expression.OpAND)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.OpAND");
							astFactory.makeASTRoot(ref currentAST, (AST)tmp3_AST);
							match(AND);
							relationalExpression();
							if (0 == inputState.guessing) {
								astFactory.addASTChild(ref currentAST, (AST)returnAST);
							}
						} else {
							goto _loop8_breakloop;
						}

					}
				_loop8_breakloop:
					;
				}    // ( ... )*
				logicalAndExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_2_);
				} else {
					throw ex;
				}
			}
			returnAST = logicalAndExpression_AST;
		}

		public void relationalExpression() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST relationalExpression_AST = null;
			GodLesZ.Library.Amf.Expression.FluorineAST e1_AST = null;
			GodLesZ.Library.Amf.Expression.FluorineAST op_AST = null;

			try {      // for error handling
				sumExpr();
				if (0 == inputState.guessing) {
					e1_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)returnAST;
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				{
					switch (LA(1)) {
						case IS:
						case EQUAL:
						case NOT_EQUAL:
						case LESS_THAN:
						case LESS_THAN_OR_EQUAL:
						case GREATER_THAN:
						case GREATER_THAN_OR_EQUAL: {
								relationalOperator();
								if (0 == inputState.guessing) {
									op_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)returnAST;
								}
								sumExpr();
								if (0 == inputState.guessing) {
									astFactory.addASTChild(ref currentAST, (AST)returnAST);
								}
								if (0 == inputState.guessing) {
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.make((AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(EXPR, op_AST.getText(), GetRelationalOperatorNodeType(op_AST.getText())), (AST)relationalExpression_AST);
									currentAST.root = relationalExpression_AST;
									if ((null != relationalExpression_AST) && (null != relationalExpression_AST.getFirstChild()))
										currentAST.child = relationalExpression_AST.getFirstChild();
									else
										currentAST.child = relationalExpression_AST;
									currentAST.advanceChildToEnd();
								}
								break;
							}
						case IN: {
								match(IN);
								listInitializer();
								if (0 == inputState.guessing) {
									astFactory.addASTChild(ref currentAST, (AST)returnAST);
								}
								if (0 == inputState.guessing) {
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.make((AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(EXPR, "IN", GetRelationalOperatorNodeType("IN")), (AST)relationalExpression_AST);
									currentAST.root = relationalExpression_AST;
									if ((null != relationalExpression_AST) && (null != relationalExpression_AST.getFirstChild()))
										currentAST.child = relationalExpression_AST.getFirstChild();
									else
										currentAST.child = relationalExpression_AST;
									currentAST.advanceChildToEnd();
								}
								break;
							}
						case BETWEEN: {
								match(BETWEEN);
								betweenExpr();
								if (0 == inputState.guessing) {
									astFactory.addASTChild(ref currentAST, (AST)returnAST);
								}
								if (0 == inputState.guessing) {
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.make((AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(EXPR, "BETWEEN", GetRelationalOperatorNodeType("BETWEEN")), (AST)relationalExpression_AST);
									currentAST.root = relationalExpression_AST;
									if ((null != relationalExpression_AST) && (null != relationalExpression_AST.getFirstChild()))
										currentAST.child = relationalExpression_AST.getFirstChild();
									else
										currentAST.child = relationalExpression_AST;
									currentAST.advanceChildToEnd();
								}
								break;
							}
						case LIKE: {
								match(LIKE);
								pattern();
								if (0 == inputState.guessing) {
									astFactory.addASTChild(ref currentAST, (AST)returnAST);
								}
								if (0 == inputState.guessing) {
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.make((AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(EXPR, "LIKE", GetRelationalOperatorNodeType("LIKE")), (AST)relationalExpression_AST);
									currentAST.root = relationalExpression_AST;
									if ((null != relationalExpression_AST) && (null != relationalExpression_AST.getFirstChild()))
										currentAST.child = relationalExpression_AST.getFirstChild();
									else
										currentAST.child = relationalExpression_AST;
									currentAST.advanceChildToEnd();
								}
								break;
							}
						case EOF:
						case AND:
						case OR:
						case RPAREN:
						case COMMA: {
								break;
							}
						default:
							if ((LA(1) == NOT) && (LA(2) == IN)) {
								match(NOT);
								match(IN);
								listInitializer();
								if (0 == inputState.guessing) {
									astFactory.addASTChild(ref currentAST, (AST)returnAST);
								}
								if (0 == inputState.guessing) {
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.make((AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(EXPR, "NOT", "GodLesZ.Library.Amf.Expression.OpNOT"), (AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.make((AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(EXPR, "IN", GetRelationalOperatorNodeType("IN")), (AST)relationalExpression_AST));
									currentAST.root = relationalExpression_AST;
									if ((null != relationalExpression_AST) && (null != relationalExpression_AST.getFirstChild()))
										currentAST.child = relationalExpression_AST.getFirstChild();
									else
										currentAST.child = relationalExpression_AST;
									currentAST.advanceChildToEnd();
								}
							} else if ((LA(1) == NOT) && (LA(2) == BETWEEN)) {
								match(NOT);
								match(BETWEEN);
								betweenExpr();
								if (0 == inputState.guessing) {
									astFactory.addASTChild(ref currentAST, (AST)returnAST);
								}
								if (0 == inputState.guessing) {
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.make((AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(EXPR, "NOT", "GodLesZ.Library.Amf.Expression.OpNOT"), (AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.make((AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(EXPR, "BETWEEN", GetRelationalOperatorNodeType("BETWEEN")), (AST)relationalExpression_AST));
									currentAST.root = relationalExpression_AST;
									if ((null != relationalExpression_AST) && (null != relationalExpression_AST.getFirstChild()))
										currentAST.child = relationalExpression_AST.getFirstChild();
									else
										currentAST.child = relationalExpression_AST;
									currentAST.advanceChildToEnd();
								}
							} else if ((LA(1) == NOT) && (LA(2) == LIKE)) {
								match(NOT);
								match(LIKE);
								pattern();
								if (0 == inputState.guessing) {
									astFactory.addASTChild(ref currentAST, (AST)returnAST);
								}
								if (0 == inputState.guessing) {
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
									relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.make((AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(EXPR, "NOT", "GodLesZ.Library.Amf.Expression.OpNOT"), (AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.make((AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(EXPR, "LIKE", GetRelationalOperatorNodeType("LIKE")), (AST)relationalExpression_AST));
									currentAST.root = relationalExpression_AST;
									if ((null != relationalExpression_AST) && (null != relationalExpression_AST.getFirstChild()))
										currentAST.child = relationalExpression_AST.getFirstChild();
									else
										currentAST.child = relationalExpression_AST;
									currentAST.advanceChildToEnd();
								}
							} else {
								throw new NoViableAltException(LT(1), getFilename());
							}
							break;
					}
				}
				relationalExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_3_);
				} else {
					throw ex;
				}
			}
			returnAST = relationalExpression_AST;
		}

		public void sumExpr() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST sumExpr_AST = null;

			try {      // for error handling
				prodExpr();
				if (0 == inputState.guessing) {
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				{    // ( ... )*
					for (; ; ) {
						if ((LA(1) == PLUS || LA(1) == MINUS)) {
							{
								if ((LA(1) == PLUS)) {
									GodLesZ.Library.Amf.Expression.OpADD tmp13_AST = null;
									tmp13_AST = (GodLesZ.Library.Amf.Expression.OpADD)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.OpADD");
									astFactory.makeASTRoot(ref currentAST, (AST)tmp13_AST);
									match(PLUS);
								} else if ((LA(1) == MINUS)) {
									GodLesZ.Library.Amf.Expression.OpSUBTRACT tmp14_AST = null;
									tmp14_AST = (GodLesZ.Library.Amf.Expression.OpSUBTRACT)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.OpSUBTRACT");
									astFactory.makeASTRoot(ref currentAST, (AST)tmp14_AST);
									match(MINUS);
								} else {
									throw new NoViableAltException(LT(1), getFilename());
								}

							}
							prodExpr();
							if (0 == inputState.guessing) {
								astFactory.addASTChild(ref currentAST, (AST)returnAST);
							}
						} else {
							goto _loop14_breakloop;
						}

					}
				_loop14_breakloop:
					;
				}    // ( ... )*
				sumExpr_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_4_);
				} else {
					throw ex;
				}
			}
			returnAST = sumExpr_AST;
		}

		public void relationalOperator() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST relationalOperator_AST = null;

			try {      // for error handling
				switch (LA(1)) {
					case EQUAL: {
							GodLesZ.Library.Amf.Expression.FluorineAST tmp15_AST = null;
							tmp15_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, (AST)tmp15_AST);
							match(EQUAL);
							relationalOperator_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case NOT_EQUAL: {
							GodLesZ.Library.Amf.Expression.FluorineAST tmp16_AST = null;
							tmp16_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, (AST)tmp16_AST);
							match(NOT_EQUAL);
							relationalOperator_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case LESS_THAN: {
							GodLesZ.Library.Amf.Expression.FluorineAST tmp17_AST = null;
							tmp17_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, (AST)tmp17_AST);
							match(LESS_THAN);
							relationalOperator_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case LESS_THAN_OR_EQUAL: {
							GodLesZ.Library.Amf.Expression.FluorineAST tmp18_AST = null;
							tmp18_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, (AST)tmp18_AST);
							match(LESS_THAN_OR_EQUAL);
							relationalOperator_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case GREATER_THAN: {
							GodLesZ.Library.Amf.Expression.FluorineAST tmp19_AST = null;
							tmp19_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, (AST)tmp19_AST);
							match(GREATER_THAN);
							relationalOperator_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case GREATER_THAN_OR_EQUAL: {
							GodLesZ.Library.Amf.Expression.FluorineAST tmp20_AST = null;
							tmp20_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, (AST)tmp20_AST);
							match(GREATER_THAN_OR_EQUAL);
							relationalOperator_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case IS: {
							GodLesZ.Library.Amf.Expression.FluorineAST tmp21_AST = null;
							tmp21_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, (AST)tmp21_AST);
							match(IS);
							relationalOperator_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					default: {
							throw new NoViableAltException(LT(1), getFilename());
						}
				}
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_5_);
				} else {
					throw ex;
				}
			}
			returnAST = relationalOperator_AST;
		}

		public void listInitializer() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST listInitializer_AST = null;

			try {      // for error handling
				GodLesZ.Library.Amf.Expression.ListInitializerNode tmp22_AST = null;
				tmp22_AST = (GodLesZ.Library.Amf.Expression.ListInitializerNode)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.ListInitializerNode");
				astFactory.makeASTRoot(ref currentAST, (AST)tmp22_AST);
				match(LPAREN);
				primaryExpression();
				if (0 == inputState.guessing) {
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				{    // ( ... )*
					for (; ; ) {
						if ((LA(1) == COMMA)) {
							match(COMMA);
							primaryExpression();
							if (0 == inputState.guessing) {
								astFactory.addASTChild(ref currentAST, (AST)returnAST);
							}
						} else {
							goto _loop38_breakloop;
						}

					}
				_loop38_breakloop:
					;
				}    // ( ... )*
				match(RPAREN);
				listInitializer_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_3_);
				} else {
					throw ex;
				}
			}
			returnAST = listInitializer_AST;
		}

		public void betweenExpr() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST betweenExpr_AST = null;
			GodLesZ.Library.Amf.Expression.FluorineAST e1_AST = null;
			GodLesZ.Library.Amf.Expression.FluorineAST e2_AST = null;

			try {      // for error handling
				sumExpr();
				if (0 == inputState.guessing) {
					e1_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)returnAST;
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				GodLesZ.Library.Amf.Expression.ListInitializerNode tmp25_AST = null;
				tmp25_AST = (GodLesZ.Library.Amf.Expression.ListInitializerNode)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.ListInitializerNode");
				astFactory.makeASTRoot(ref currentAST, (AST)tmp25_AST);
				match(AND);
				sumExpr();
				if (0 == inputState.guessing) {
					e2_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)returnAST;
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				betweenExpr_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_3_);
				} else {
					throw ex;
				}
			}
			returnAST = betweenExpr_AST;
		}

		public void pattern() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST pattern_AST = null;

			try {      // for error handling
				switch (LA(1)) {
					case EOF:
					case AND:
					case OR:
					case RPAREN:
					case COMMA: {
							pattern_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case FALSE:
					case TRUE:
					case NULL_LITERAL:
					case INTEGER_LITERAL:
					case HEXADECIMAL_INTEGER_LITERAL:
					case REAL_LITERAL:
					case STRING_LITERAL:
					case LITERAL_date: {
							literal();
							if (0 == inputState.guessing) {
								astFactory.addASTChild(ref currentAST, (AST)returnAST);
							}
							pattern_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case POUND:
					case ID: {
							functionOrVar();
							if (0 == inputState.guessing) {
								astFactory.addASTChild(ref currentAST, (AST)returnAST);
							}
							pattern_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					default: {
							throw new NoViableAltException(LT(1), getFilename());
						}
				}
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_3_);
				} else {
					throw ex;
				}
			}
			returnAST = pattern_AST;
		}

		public void prodExpr() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST prodExpr_AST = null;

			try {      // for error handling
				powExpr();
				if (0 == inputState.guessing) {
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				{    // ( ... )*
					for (; ; ) {
						if (((LA(1) >= STAR && LA(1) <= MOD))) {
							{
								switch (LA(1)) {
									case STAR: {
											GodLesZ.Library.Amf.Expression.OpMULTIPLY tmp26_AST = null;
											tmp26_AST = (GodLesZ.Library.Amf.Expression.OpMULTIPLY)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.OpMULTIPLY");
											astFactory.makeASTRoot(ref currentAST, (AST)tmp26_AST);
											match(STAR);
											break;
										}
									case DIV: {
											GodLesZ.Library.Amf.Expression.OpDIVIDE tmp27_AST = null;
											tmp27_AST = (GodLesZ.Library.Amf.Expression.OpDIVIDE)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.OpDIVIDE");
											astFactory.makeASTRoot(ref currentAST, (AST)tmp27_AST);
											match(DIV);
											break;
										}
									case MOD: {
											GodLesZ.Library.Amf.Expression.OpMODULUS tmp28_AST = null;
											tmp28_AST = (GodLesZ.Library.Amf.Expression.OpMODULUS)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.OpMODULUS");
											astFactory.makeASTRoot(ref currentAST, (AST)tmp28_AST);
											match(MOD);
											break;
										}
									default: {
											throw new NoViableAltException(LT(1), getFilename());
										}
								}
							}
							powExpr();
							if (0 == inputState.guessing) {
								astFactory.addASTChild(ref currentAST, (AST)returnAST);
							}
						} else {
							goto _loop18_breakloop;
						}

					}
				_loop18_breakloop:
					;
				}    // ( ... )*
				prodExpr_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_6_);
				} else {
					throw ex;
				}
			}
			returnAST = prodExpr_AST;
		}

		public void powExpr() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST powExpr_AST = null;

			try {      // for error handling
				unaryExpression();
				if (0 == inputState.guessing) {
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				{
					if ((LA(1) == POWER)) {
						GodLesZ.Library.Amf.Expression.OpPOWER tmp29_AST = null;
						tmp29_AST = (GodLesZ.Library.Amf.Expression.OpPOWER)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.OpPOWER");
						astFactory.makeASTRoot(ref currentAST, (AST)tmp29_AST);
						match(POWER);
						unaryExpression();
						if (0 == inputState.guessing) {
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					} else if ((tokenSet_7_.member(LA(1)))) {
					} else {
						throw new NoViableAltException(LT(1), getFilename());
					}

				}
				powExpr_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_7_);
				} else {
					throw ex;
				}
			}
			returnAST = powExpr_AST;
		}

		public void unaryExpression() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST unaryExpression_AST = null;

			try {      // for error handling
				if ((LA(1) == NOT || LA(1) == PLUS || LA(1) == MINUS)) {
					{
						switch (LA(1)) {
							case PLUS: {
									GodLesZ.Library.Amf.Expression.OpUnaryPlus tmp30_AST = null;
									tmp30_AST = (GodLesZ.Library.Amf.Expression.OpUnaryPlus)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.OpUnaryPlus");
									astFactory.makeASTRoot(ref currentAST, (AST)tmp30_AST);
									match(PLUS);
									break;
								}
							case MINUS: {
									GodLesZ.Library.Amf.Expression.OpUnaryMinus tmp31_AST = null;
									tmp31_AST = (GodLesZ.Library.Amf.Expression.OpUnaryMinus)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.OpUnaryMinus");
									astFactory.makeASTRoot(ref currentAST, (AST)tmp31_AST);
									match(MINUS);
									break;
								}
							case NOT: {
									GodLesZ.Library.Amf.Expression.OpNOT tmp32_AST = null;
									tmp32_AST = (GodLesZ.Library.Amf.Expression.OpNOT)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.OpNOT");
									astFactory.makeASTRoot(ref currentAST, (AST)tmp32_AST);
									match(NOT);
									break;
								}
							default: {
									throw new NoViableAltException(LT(1), getFilename());
								}
						}
					}
					unaryExpression();
					if (0 == inputState.guessing) {
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					unaryExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
				} else if ((tokenSet_8_.member(LA(1)))) {
					primaryExpression();
					if (0 == inputState.guessing) {
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					unaryExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
				} else {
					throw new NoViableAltException(LT(1), getFilename());
				}

			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_9_);
				} else {
					throw ex;
				}
			}
			returnAST = unaryExpression_AST;
		}

		public void primaryExpression() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST primaryExpression_AST = null;

			try {      // for error handling
				switch (LA(1)) {
					case LPAREN: {
							parenExpr();
							if (0 == inputState.guessing) {
								astFactory.addASTChild(ref currentAST, (AST)returnAST);
							}
							primaryExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case FALSE:
					case TRUE:
					case NULL_LITERAL:
					case INTEGER_LITERAL:
					case HEXADECIMAL_INTEGER_LITERAL:
					case REAL_LITERAL:
					case STRING_LITERAL:
					case LITERAL_date: {
							literal();
							if (0 == inputState.guessing) {
								astFactory.addASTChild(ref currentAST, (AST)returnAST);
							}
							primaryExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case POUND:
					case ID: {
							functionOrVar();
							if (0 == inputState.guessing) {
								astFactory.addASTChild(ref currentAST, (AST)returnAST);
							}
							if (0 == inputState.guessing) {
								primaryExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
								primaryExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.make((AST)(GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(EXPR, "expression", "GodLesZ.Library.Amf.Expression.Expression"), (AST)primaryExpression_AST);
								currentAST.root = primaryExpression_AST;
								if ((null != primaryExpression_AST) && (null != primaryExpression_AST.getFirstChild()))
									currentAST.child = primaryExpression_AST.getFirstChild();
								else
									currentAST.child = primaryExpression_AST;
								currentAST.advanceChildToEnd();
							}
							primaryExpression_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					default: {
							throw new NoViableAltException(LT(1), getFilename());
						}
				}
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_9_);
				} else {
					throw ex;
				}
			}
			returnAST = primaryExpression_AST;
		}

		public void parenExpr() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST parenExpr_AST = null;

			try {      // for error handling
				match(LPAREN);
				expression();
				if (0 == inputState.guessing) {
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				match(RPAREN);
				parenExpr_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_9_);
				} else {
					throw ex;
				}
			}
			returnAST = parenExpr_AST;
		}

		public void literal() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST literal_AST = null;

			try {      // for error handling
				switch (LA(1)) {
					case NULL_LITERAL: {
							GodLesZ.Library.Amf.Expression.NullLiteralNode tmp35_AST = null;
							tmp35_AST = (GodLesZ.Library.Amf.Expression.NullLiteralNode)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.NullLiteralNode");
							astFactory.addASTChild(ref currentAST, (AST)tmp35_AST);
							match(NULL_LITERAL);
							literal_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case INTEGER_LITERAL: {
							GodLesZ.Library.Amf.Expression.IntLiteralNode tmp36_AST = null;
							tmp36_AST = (GodLesZ.Library.Amf.Expression.IntLiteralNode)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.IntLiteralNode");
							astFactory.addASTChild(ref currentAST, (AST)tmp36_AST);
							match(INTEGER_LITERAL);
							literal_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case HEXADECIMAL_INTEGER_LITERAL: {
							GodLesZ.Library.Amf.Expression.HexLiteralNode tmp37_AST = null;
							tmp37_AST = (GodLesZ.Library.Amf.Expression.HexLiteralNode)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.HexLiteralNode");
							astFactory.addASTChild(ref currentAST, (AST)tmp37_AST);
							match(HEXADECIMAL_INTEGER_LITERAL);
							literal_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case REAL_LITERAL: {
							GodLesZ.Library.Amf.Expression.RealLiteralNode tmp38_AST = null;
							tmp38_AST = (GodLesZ.Library.Amf.Expression.RealLiteralNode)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.RealLiteralNode");
							astFactory.addASTChild(ref currentAST, (AST)tmp38_AST);
							match(REAL_LITERAL);
							literal_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case STRING_LITERAL: {
							GodLesZ.Library.Amf.Expression.StringLiteralNode tmp39_AST = null;
							tmp39_AST = (GodLesZ.Library.Amf.Expression.StringLiteralNode)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.StringLiteralNode");
							astFactory.addASTChild(ref currentAST, (AST)tmp39_AST);
							match(STRING_LITERAL);
							literal_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case FALSE:
					case TRUE: {
							boolLiteral();
							if (0 == inputState.guessing) {
								astFactory.addASTChild(ref currentAST, (AST)returnAST);
							}
							literal_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					case LITERAL_date: {
							dateLiteral();
							if (0 == inputState.guessing) {
								astFactory.addASTChild(ref currentAST, (AST)returnAST);
							}
							literal_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
							break;
						}
					default: {
							throw new NoViableAltException(LT(1), getFilename());
						}
				}
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_9_);
				} else {
					throw ex;
				}
			}
			returnAST = literal_AST;
		}

		public void functionOrVar() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST functionOrVar_AST = null;

			try {      // for error handling
				bool synPredMatched28 = false;
				if (((LA(1) == POUND))) {
					int _m28 = mark();
					synPredMatched28 = true;
					inputState.guessing++;
					try {
						{
							match(POUND);
							match(ID);
							match(LPAREN);
						}
					} catch (RecognitionException) {
						synPredMatched28 = false;
					}
					rewind(_m28);
					inputState.guessing--;
				}
				if (synPredMatched28) {
					function();
					if (0 == inputState.guessing) {
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					functionOrVar_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
				} else if ((LA(1) == ID)) {
					var();
					if (0 == inputState.guessing) {
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					functionOrVar_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
				} else {
					throw new NoViableAltException(LT(1), getFilename());
				}

			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_9_);
				} else {
					throw ex;
				}
			}
			returnAST = functionOrVar_AST;
		}

		public void function() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST function_AST = null;

			try {      // for error handling
				match(POUND);
				GodLesZ.Library.Amf.Expression.FunctionNode tmp41_AST = null;
				tmp41_AST = (GodLesZ.Library.Amf.Expression.FunctionNode)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.FunctionNode");
				astFactory.makeASTRoot(ref currentAST, (AST)tmp41_AST);
				match(ID);
				methodArgs();
				if (0 == inputState.guessing) {
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				function_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_9_);
				} else {
					throw ex;
				}
			}
			returnAST = function_AST;
		}

		public void var() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST var_AST = null;

			try {      // for error handling
				GodLesZ.Library.Amf.Expression.VariableNode tmp42_AST = null;
				tmp42_AST = (GodLesZ.Library.Amf.Expression.VariableNode)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.VariableNode");
				astFactory.makeASTRoot(ref currentAST, (AST)tmp42_AST);
				match(ID);
				var_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_9_);
				} else {
					throw ex;
				}
			}
			returnAST = var_AST;
		}

		public void methodArgs() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST methodArgs_AST = null;

			try {      // for error handling
				match(LPAREN);
				{
					if ((tokenSet_5_.member(LA(1)))) {
						argument();
						if (0 == inputState.guessing) {
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
						{    // ( ... )*
							for (; ; ) {
								if ((LA(1) == COMMA)) {
									match(COMMA);
									argument();
									if (0 == inputState.guessing) {
										astFactory.addASTChild(ref currentAST, (AST)returnAST);
									}
								} else {
									goto _loop33_breakloop;
								}

							}
						_loop33_breakloop:
							;
						}    // ( ... )*
					} else if ((LA(1) == RPAREN)) {
					} else {
						throw new NoViableAltException(LT(1), getFilename());
					}

				}
				match(RPAREN);
				methodArgs_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_9_);
				} else {
					throw ex;
				}
			}
			returnAST = methodArgs_AST;
		}

		public void argument() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST argument_AST = null;

			try {      // for error handling
				expression();
				if (0 == inputState.guessing) {
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				argument_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_10_);
				} else {
					throw ex;
				}
			}
			returnAST = argument_AST;
		}

		public void boolLiteral() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST boolLiteral_AST = null;

			try {      // for error handling
				if ((LA(1) == TRUE)) {
					GodLesZ.Library.Amf.Expression.BooleanLiteralNode tmp46_AST = null;
					tmp46_AST = (GodLesZ.Library.Amf.Expression.BooleanLiteralNode)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.BooleanLiteralNode");
					astFactory.addASTChild(ref currentAST, (AST)tmp46_AST);
					match(TRUE);
					boolLiteral_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
				} else if ((LA(1) == FALSE)) {
					GodLesZ.Library.Amf.Expression.BooleanLiteralNode tmp47_AST = null;
					tmp47_AST = (GodLesZ.Library.Amf.Expression.BooleanLiteralNode)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.BooleanLiteralNode");
					astFactory.addASTChild(ref currentAST, (AST)tmp47_AST);
					match(FALSE);
					boolLiteral_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
				} else {
					throw new NoViableAltException(LT(1), getFilename());
				}

			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_9_);
				} else {
					throw ex;
				}
			}
			returnAST = boolLiteral_AST;
		}

		public void dateLiteral() //throws RecognitionException, TokenStreamException
	{

			returnAST = null;
			ASTPair currentAST = new ASTPair();
			GodLesZ.Library.Amf.Expression.FluorineAST dateLiteral_AST = null;

			try {      // for error handling
				GodLesZ.Library.Amf.Expression.DateLiteralNode tmp48_AST = null;
				tmp48_AST = (GodLesZ.Library.Amf.Expression.DateLiteralNode)astFactory.create(LT(1), "GodLesZ.Library.Amf.Expression.DateLiteralNode");
				astFactory.makeASTRoot(ref currentAST, (AST)tmp48_AST);
				match(LITERAL_date);
				match(LPAREN);
				GodLesZ.Library.Amf.Expression.FluorineAST tmp50_AST = null;
				tmp50_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp50_AST);
				match(STRING_LITERAL);
				{
					if ((LA(1) == COMMA)) {
						match(COMMA);
						GodLesZ.Library.Amf.Expression.FluorineAST tmp52_AST = null;
						tmp52_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, (AST)tmp52_AST);
						match(STRING_LITERAL);
					} else if ((LA(1) == RPAREN)) {
					} else {
						throw new NoViableAltException(LT(1), getFilename());
					}

				}
				match(RPAREN);
				dateLiteral_AST = (GodLesZ.Library.Amf.Expression.FluorineAST)currentAST.root;
			} catch (RecognitionException ex) {
				if (0 == inputState.guessing) {
					reportError(ex);
					recover(ex, tokenSet_9_);
				} else {
					throw ex;
				}
			}
			returnAST = dateLiteral_AST;
		}

		public new GodLesZ.Library.Amf.Expression.FluorineAST getAST() {
			return (GodLesZ.Library.Amf.Expression.FluorineAST)returnAST;
		}

		private void initializeFactory() {
			if (astFactory == null) {
				astFactory = new ASTFactory("GodLesZ.Library.Amf.Expression.FluorineAST");
			}
			initializeASTFactory(astFactory);
		}
		static public void initializeASTFactory(ASTFactory factory) {
			factory.setMaxNodeType(56);
		}

		public static readonly string[] tokenNames_ = new string[] {
		@"""<0>""",
		@"""EOF""",
		@"""<2>""",
		@"""NULL_TREE_LOOKAHEAD""",
		@"""EXPR""",
		@"""OPERAND""",
		@"""FALSE""",
		@"""TRUE""",
		@"""AND""",
		@"""OR""",
		@"""NOT""",
		@"""IN""",
		@"""IS""",
		@"""BETWEEN""",
		@"""LIKE""",
		@"""NULL""",
		@"""PLUS""",
		@"""MINUS""",
		@"""STAR""",
		@"""DIV""",
		@"""MOD""",
		@"""POWER""",
		@"""LPAREN""",
		@"""RPAREN""",
		@"""POUND""",
		@"""ID""",
		@"""COMMA""",
		@"""INTEGER_LITERAL""",
		@"""HEXADECIMAL_INTEGER_LITERAL""",
		@"""REAL_LITERAL""",
		@"""STRING_LITERAL""",
		@"""date""",
		@"""EQUAL""",
		@"""NOT_EQUAL""",
		@"""LESS_THAN""",
		@"""LESS_THAN_OR_EQUAL""",
		@"""GREATER_THAN""",
		@"""GREATER_THAN_OR_EQUAL""",
		@"""WS""",
		@"""AT""",
		@"""QMARK""",
		@"""DOLLAR""",
		@"""LBRACKET""",
		@"""RBRACKET""",
		@"""LCURLY""",
		@"""RCURLY""",
		@"""SEMI""",
		@"""COLON""",
		@"""DOT_ESCAPED""",
		@"""APOS""",
		@"""NUMERIC_LITERAL""",
		@"""DECIMAL_DIGIT""",
		@"""INTEGER_TYPE_SUFFIX""",
		@"""HEX_DIGIT""",
		@"""EXPONENT_PART""",
		@"""SIGN""",
		@"""REAL_TYPE_SUFFIX"""
	};

		private static long[] mk_tokenSet_0_() {
			long[] data = { 2L, 0L };
			return data;
		}
		public static readonly BitSet tokenSet_0_ = new BitSet(mk_tokenSet_0_());
		private static long[] mk_tokenSet_1_() {
			long[] data = { 75497474L, 0L };
			return data;
		}
		public static readonly BitSet tokenSet_1_ = new BitSet(mk_tokenSet_1_());
		private static long[] mk_tokenSet_2_() {
			long[] data = { 75497986L, 0L };
			return data;
		}
		public static readonly BitSet tokenSet_2_ = new BitSet(mk_tokenSet_2_());
		private static long[] mk_tokenSet_3_() {
			long[] data = { 75498242L, 0L };
			return data;
		}
		public static readonly BitSet tokenSet_3_ = new BitSet(mk_tokenSet_3_());
		private static long[] mk_tokenSet_4_() {
			long[] data = { 270658469634L, 0L };
			return data;
		}
		public static readonly BitSet tokenSet_4_ = new BitSet(mk_tokenSet_4_());
		private static long[] mk_tokenSet_5_() {
			long[] data = { 4215506112L, 0L };
			return data;
		}
		public static readonly BitSet tokenSet_5_ = new BitSet(mk_tokenSet_5_());
		private static long[] mk_tokenSet_6_() {
			long[] data = { 270658666242L, 0L };
			return data;
		}
		public static readonly BitSet tokenSet_6_ = new BitSet(mk_tokenSet_6_());
		private static long[] mk_tokenSet_7_() {
			long[] data = { 270660501250L, 0L };
			return data;
		}
		public static readonly BitSet tokenSet_7_ = new BitSet(mk_tokenSet_7_());
		private static long[] mk_tokenSet_8_() {
			long[] data = { 4215308480L, 0L };
			return data;
		}
		public static readonly BitSet tokenSet_8_ = new BitSet(mk_tokenSet_8_());
		private static long[] mk_tokenSet_9_() {
			long[] data = { 270662598402L, 0L };
			return data;
		}
		public static readonly BitSet tokenSet_9_ = new BitSet(mk_tokenSet_9_());
		private static long[] mk_tokenSet_10_() {
			long[] data = { 75497472L, 0L };
			return data;
		}
		public static readonly BitSet tokenSet_10_ = new BitSet(mk_tokenSet_10_());

	}
}
