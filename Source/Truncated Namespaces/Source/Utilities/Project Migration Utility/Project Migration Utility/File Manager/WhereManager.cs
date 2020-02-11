using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectMigrationUtility.FileManager
{
	internal class WhereManager
	{
		private List<string> andNameEquals = new List<string>();

		private List<string> andFullPathEquals = new List<string>();

		private List<string> andExtensionEquals = new List<string>();

		private List<string> andNameNotEqual = new List<string>();

		private List<string> andFullPathNotEqual = new List<string>();

		private List<string> andExtensionNotEqual = new List<string>();

		private List<string> andNameContains = new List<string>();

		private List<string> andFullPathContains = new List<string>();

		private List<string> andExtensionContains = new List<string>();

		private List<string> andNameNotContains = new List<string>();

		private List<string> andFullPathNotContains = new List<string>();

		private List<string> andExtensionNotContains = new List<string>();

		private List<string> andLenghtEquals = new List<string>();

		private List<string> andLenghtGreaterThan = new List<string>();

		private List<string> andLenghtLessThan = new List<string>();

		private List<string> andLenghtGreaterThanOrEqual = new List<string>();

		private List<string> andLenghtLessThanOrEqual = new List<string>();

		private List<string> andCreationTimeEquals = new List<string>();

		private List<string> andCreationTimeGreaterThan = new List<string>();

		private List<string> andCreationTimeLessThan = new List<string>();

		private List<string> andCreationTimeGreaterThanOrEqual = new List<string>();

		private List<string> andCreationTimeLessThanOrEqual = new List<string>();

		private List<string> andLastWriteTimeEquals = new List<string>();

		private List<string> andLastWriteTimeGreaterThan = new List<string>();

		private List<string> andLastWriteTimeLessThan = new List<string>();

		private List<string> andLastWriteTimeGreaterThanOrEqual = new List<string>();

		private List<string> andLastWriteTimeLessThanOrEqual = new List<string>();

		private List<string> orNameEquals = new List<string>();

		private List<string> orFullPathEquals = new List<string>();

		private List<string> orExtensionEquals = new List<string>();

		private List<string> orNameNotEqual = new List<string>();

		private List<string> orFullPathNotEqual = new List<string>();

		private List<string> orExtensionNotEqual = new List<string>();

		private List<string> orNameContains = new List<string>();

		private List<string> orFullPathContains = new List<string>();

		private List<string> orExtensionContains = new List<string>();

		private List<string> orNameNotContains = new List<string>();

		private List<string> orFullPathNotContains = new List<string>();

		private List<string> orExtensionNotContains = new List<string>();

		private List<string> orLenghtEquals = new List<string>();

		private List<string> orLenghtGreaterThan = new List<string>();

		private List<string> orLenghtLessThan = new List<string>();

		private List<string> orLenghtGreaterThanOrEqual = new List<string>();

		private List<string> orLenghtLessThanOrEqual = new List<string>();

		private List<string> orCreationTimeEquals = new List<string>();

		private List<string> orCreationTimeGreaterThan = new List<string>();

		private List<string> orCreationTimeLessThan = new List<string>();

		private List<string> orCreationTimeGreaterThanOrEqual = new List<string>();

		private List<string> orCreationTimeLessThanOrEqual = new List<string>();

		private List<string> orLastWriteTimeEquals = new List<string>();

		private List<string> orLastWriteTimeGreaterThan = new List<string>();

		private List<string> orLastWriteTimeLessThan = new List<string>();

		private List<string> orLastWriteTimeGreaterThanOrEqual = new List<string>();

		private List<string> orLastWriteTimeLessThanOrEqual = new List<string>();

		private ParameterExpression expressionParameter = Expression.Parameter(typeof(FileInfo), "fi");

		private string sqlWhereClause;

		private string sqlOrderByClause;

		private Dictionary<string, object> appConfig = new Dictionary<string, object>();

		private List<string> AndCreationTimeEquals
		{
			get
			{
				return this.andCreationTimeEquals;
			}
			set
			{
				this.andCreationTimeEquals = value;
			}
		}

		private List<string> AndCreationTimeGreaterThan
		{
			get
			{
				return this.andCreationTimeGreaterThan;
			}
			set
			{
				this.andCreationTimeGreaterThan = value;
			}
		}

		private List<string> AndCreationTimeGreaterThanOrEqual
		{
			get
			{
				return this.andCreationTimeGreaterThanOrEqual;
			}
			set
			{
				this.andCreationTimeGreaterThanOrEqual = value;
			}
		}

		private List<string> AndCreationTimeLessThan
		{
			get
			{
				return this.andCreationTimeLessThan;
			}
			set
			{
				this.andCreationTimeLessThan = value;
			}
		}

		private List<string> AndCreationTimeLessThanOrEqual
		{
			get
			{
				return this.andCreationTimeLessThanOrEqual;
			}
			set
			{
				this.andCreationTimeLessThanOrEqual = value;
			}
		}

		private List<string> AndExtensionContains
		{
			get
			{
				return this.andExtensionContains;
			}
			set
			{
				this.andExtensionContains = value;
			}
		}

		private List<string> AndExtensionEquals
		{
			get
			{
				return this.andExtensionEquals;
			}
			set
			{
				this.andExtensionEquals = value;
			}
		}

		private List<string> AndExtensionNotContains
		{
			get
			{
				return this.andExtensionNotContains;
			}
			set
			{
				this.andExtensionNotContains = value;
			}
		}

		private List<string> AndExtensionNotEqual
		{
			get
			{
				return this.andExtensionNotEqual;
			}
			set
			{
				this.andExtensionNotEqual = value;
			}
		}

		private List<string> AndFullPathContains
		{
			get
			{
				return this.andFullPathContains;
			}
			set
			{
				this.andFullPathContains = value;
			}
		}

		private List<string> AndFullPathEquals
		{
			get
			{
				return this.andFullPathEquals;
			}
			set
			{
				this.andFullPathEquals = value;
			}
		}

		private List<string> AndFullPathNotContains
		{
			get
			{
				return this.andFullPathNotContains;
			}
			set
			{
				this.andFullPathNotContains = value;
			}
		}

		private List<string> AndFullPathNotEqual
		{
			get
			{
				return this.andFullPathNotEqual;
			}
			set
			{
				this.andFullPathNotEqual = value;
			}
		}

		private List<string> AndLastWriteTimeEquals
		{
			get
			{
				return this.andLastWriteTimeEquals;
			}
			set
			{
				this.andLastWriteTimeEquals = value;
			}
		}

		private List<string> AndLastWriteTimeGreaterThan
		{
			get
			{
				return this.andLastWriteTimeGreaterThan;
			}
			set
			{
				this.andLastWriteTimeGreaterThan = value;
			}
		}

		private List<string> AndLastWriteTimeGreaterThanOrEqual
		{
			get
			{
				return this.andLastWriteTimeGreaterThanOrEqual;
			}
			set
			{
				this.andLastWriteTimeGreaterThanOrEqual = value;
			}
		}

		private List<string> AndLastWriteTimeLessThan
		{
			get
			{
				return this.andLastWriteTimeLessThan;
			}
			set
			{
				this.andLastWriteTimeLessThan = value;
			}
		}

		private List<string> AndLastWriteTimeLessThanOrEqual
		{
			get
			{
				return this.andLastWriteTimeLessThanOrEqual;
			}
			set
			{
				this.andLastWriteTimeLessThanOrEqual = value;
			}
		}

		private List<string> AndLenghtEquals
		{
			get
			{
				return this.andLenghtEquals;
			}
			set
			{
				this.andLenghtEquals = value;
			}
		}

		private List<string> AndLenghtGreaterThan
		{
			get
			{
				return this.andLenghtGreaterThan;
			}
			set
			{
				this.andLenghtGreaterThan = value;
			}
		}

		private List<string> AndLenghtGreaterThanOrEqual
		{
			get
			{
				return this.andLenghtGreaterThanOrEqual;
			}
			set
			{
				this.andLenghtGreaterThanOrEqual = value;
			}
		}

		private List<string> AndLenghtLessThan
		{
			get
			{
				return this.andLenghtLessThan;
			}
			set
			{
				this.andLenghtLessThan = value;
			}
		}

		private List<string> AndLenghtLessThanOrEqual
		{
			get
			{
				return this.andLenghtLessThanOrEqual;
			}
			set
			{
				this.andLenghtLessThanOrEqual = value;
			}
		}

		private List<string> AndNameContains
		{
			get
			{
				return this.andNameContains;
			}
			set
			{
				this.andNameContains = value;
			}
		}

		private List<string> AndNameEquals
		{
			get
			{
				return this.andNameEquals;
			}
			set
			{
				this.andNameEquals = value;
			}
		}

		private List<string> AndNameNotContains
		{
			get
			{
				return this.andNameNotContains;
			}
			set
			{
				this.andNameNotContains = value;
			}
		}

		private List<string> AndNameNotEqual
		{
			get
			{
				return this.andNameNotEqual;
			}
			set
			{
				this.andNameNotEqual = value;
			}
		}

		public Dictionary<string, object> AppConfig
		{
			get
			{
				return this.appConfig;
			}
			set
			{
				this.appConfig = value;
			}
		}

		private ParameterExpression ExpressionParameter
		{
			get
			{
				return this.expressionParameter;
			}
		}

		public List<string> OrCreationTimeEquals
		{
			get
			{
				return this.orCreationTimeEquals;
			}
			set
			{
				this.orCreationTimeEquals = value;
			}
		}

		private List<string> OrCreationTimeGreaterThan
		{
			get
			{
				return this.orCreationTimeGreaterThan;
			}
			set
			{
				this.orCreationTimeGreaterThan = value;
			}
		}

		private List<string> OrCreationTimeGreaterThanOrEqual
		{
			get
			{
				return this.orCreationTimeGreaterThanOrEqual;
			}
			set
			{
				this.orCreationTimeGreaterThanOrEqual = value;
			}
		}

		private List<string> OrCreationTimeLessThan
		{
			get
			{
				return this.orCreationTimeLessThan;
			}
			set
			{
				this.orCreationTimeLessThan = value;
			}
		}

		private List<string> OrCreationTimeLessThanOrEqual
		{
			get
			{
				return this.orCreationTimeLessThanOrEqual;
			}
			set
			{
				this.orCreationTimeLessThanOrEqual = value;
			}
		}

		private List<string> OrExtensionContains
		{
			get
			{
				return this.orExtensionContains;
			}
			set
			{
				this.orExtensionContains = value;
			}
		}

		private List<string> OrExtensionEquals
		{
			get
			{
				return this.orExtensionEquals;
			}
			set
			{
				this.orExtensionEquals = value;
			}
		}

		private List<string> OrExtensionNotContains
		{
			get
			{
				return this.orExtensionNotContains;
			}
			set
			{
				this.orExtensionNotContains = value;
			}
		}

		private List<string> OrExtensionNotEqual
		{
			get
			{
				return this.orExtensionNotEqual;
			}
			set
			{
				this.orExtensionNotEqual = value;
			}
		}

		private List<string> OrFullPathContains
		{
			get
			{
				return this.orFullPathContains;
			}
			set
			{
				this.orFullPathContains = value;
			}
		}

		private List<string> OrFullPathEquals
		{
			get
			{
				return this.orFullPathEquals;
			}
			set
			{
				this.orFullPathEquals = value;
			}
		}

		private List<string> OrFullPathNotContains
		{
			get
			{
				return this.orFullPathNotContains;
			}
			set
			{
				this.orFullPathNotContains = value;
			}
		}

		private List<string> OrFullPathNotEqual
		{
			get
			{
				return this.orFullPathNotEqual;
			}
			set
			{
				this.orFullPathNotEqual = value;
			}
		}

		public List<string> OrLastWriteTimeEquals
		{
			get
			{
				return this.orLastWriteTimeEquals;
			}
			set
			{
				this.orLastWriteTimeEquals = value;
			}
		}

		private List<string> OrLastWriteTimeGreaterThan
		{
			get
			{
				return this.orLastWriteTimeGreaterThan;
			}
			set
			{
				this.orLastWriteTimeGreaterThan = value;
			}
		}

		private List<string> OrLastWriteTimeGreaterThanOrEqual
		{
			get
			{
				return this.orLastWriteTimeGreaterThanOrEqual;
			}
			set
			{
				this.orLastWriteTimeGreaterThanOrEqual = value;
			}
		}

		private List<string> OrLastWriteTimeLessThan
		{
			get
			{
				return this.orLastWriteTimeLessThan;
			}
			set
			{
				this.orLastWriteTimeLessThan = value;
			}
		}

		private List<string> OrLastWriteTimeLessThanOrEqual
		{
			get
			{
				return this.orLastWriteTimeLessThanOrEqual;
			}
			set
			{
				this.orLastWriteTimeLessThanOrEqual = value;
			}
		}

		private List<string> OrLenghtEquals
		{
			get
			{
				return this.orLenghtEquals;
			}
			set
			{
				this.orLenghtEquals = value;
			}
		}

		private List<string> OrLenghtGreaterThan
		{
			get
			{
				return this.orLenghtGreaterThan;
			}
			set
			{
				this.orLenghtGreaterThan = value;
			}
		}

		private List<string> OrLenghtGreaterThanOrEqual
		{
			get
			{
				return this.orLenghtGreaterThanOrEqual;
			}
			set
			{
				this.orLenghtGreaterThanOrEqual = value;
			}
		}

		private List<string> OrLenghtLessThan
		{
			get
			{
				return this.orLenghtLessThan;
			}
			set
			{
				this.orLenghtLessThan = value;
			}
		}

		private List<string> OrLenghtLessThanOrEqual
		{
			get
			{
				return this.orLenghtLessThanOrEqual;
			}
			set
			{
				this.orLenghtLessThanOrEqual = value;
			}
		}

		private List<string> OrNameContains
		{
			get
			{
				return this.orNameContains;
			}
			set
			{
				this.orNameContains = value;
			}
		}

		private List<string> OrNameEquals
		{
			get
			{
				return this.orNameEquals;
			}
			set
			{
				this.orNameEquals = value;
			}
		}

		private List<string> OrNameNotContains
		{
			get
			{
				return this.orNameNotContains;
			}
			set
			{
				this.orNameNotContains = value;
			}
		}

		private List<string> OrNameNotEqual
		{
			get
			{
				return this.orNameNotEqual;
			}
			set
			{
				this.orNameNotEqual = value;
			}
		}

		public string SqlOrderByClause
		{
			get
			{
				return this.sqlOrderByClause;
			}
			set
			{
				this.sqlOrderByClause = value;
			}
		}

		private string SqlWhereClause
		{
			get
			{
				return this.sqlWhereClause;
			}
			set
			{
				this.sqlWhereClause = value;
			}
		}

		public WhereManager(Dictionary<string, object> appConfig)
		{
			this.AppConfig = appConfig;
		}

		private Expression BuildAnAllwaysTrueExpression()
		{
			ConstantExpression expressionConstantValue = Expression.Constant("hello");
			MethodInfo expressionMethod = typeof(string).GetMethod("Contains");
			ConstantExpression constantExpression = Expression.Constant("hello");
			Expression[] expressionArray = new Expression[] { expressionConstantValue };
			return Expression.Call(constantExpression, expressionMethod, expressionArray);
		}

		private Expression BuildContainsExpression(string property, string value)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			MethodInfo expressionMethod = typeof(string).GetMethod("Contains");
			Expression[] expressionArray = new Expression[] { Expression.Constant(value) };
			return Expression.Call(expressionProperty, expressionMethod, expressionArray);
		}

		private Expression buildDateEqualsExpression(string property, DateTime value)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			Type type = typeof(DateTime);
			Type[] typeArray = new Type[] { typeof(DateTime) };
			MethodInfo expressionMethod = type.GetMethod("Equals", typeArray);
			MemberExpression memberExpression = Expression.Property(expressionProperty, "Date");
			Expression[] expressionArray = new Expression[] { Expression.Constant(value.Date) };
			return Expression.Call(memberExpression, expressionMethod, expressionArray);
		}

		private Expression BuildEqualsExpression(string property, string condition)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			MethodInfo expressionMethod = typeof(List<string>).GetMethod("Contains");
			Expression finalExpression = null;
			if (property == "Name" && condition == "AND")
			{
				ConstantExpression constantExpression = Expression.Constant(this.AndNameEquals);
				Expression[] expressionArray = new Expression[] { expressionProperty };
				finalExpression = Expression.Call(constantExpression, expressionMethod, expressionArray);
			}
			else if (property == "DirectoryName" && condition == "AND")
			{
				ConstantExpression constantExpression1 = Expression.Constant(this.AndFullPathEquals);
				Expression[] expressionArray1 = new Expression[] { expressionProperty };
				finalExpression = Expression.Call(constantExpression1, expressionMethod, expressionArray1);
			}
			else if (property == "Extension" && condition == "AND")
			{
				ConstantExpression constantExpression2 = Expression.Constant(this.AndExtensionEquals);
				Expression[] expressionArray2 = new Expression[] { expressionProperty };
				finalExpression = Expression.Call(constantExpression2, expressionMethod, expressionArray2);
			}
			else if (property == "Name" && condition == "OR")
			{
				ConstantExpression constantExpression3 = Expression.Constant(this.OrNameEquals);
				Expression[] expressionArray3 = new Expression[] { expressionProperty };
				finalExpression = Expression.Call(constantExpression3, expressionMethod, expressionArray3);
			}
			else if (property == "DirectoryName" && condition == "OR")
			{
				ConstantExpression constantExpression4 = Expression.Constant(this.OrFullPathEquals);
				Expression[] expressionArray4 = new Expression[] { expressionProperty };
				finalExpression = Expression.Call(constantExpression4, expressionMethod, expressionArray4);
			}
			else if (property == "Extension" && condition == "OR")
			{
				ConstantExpression constantExpression5 = Expression.Constant(this.OrExtensionEquals);
				Expression[] expressionArray5 = new Expression[] { expressionProperty };
				finalExpression = Expression.Call(constantExpression5, expressionMethod, expressionArray5);
			}
			return finalExpression;
		}

		private Expression BuildGreaterThanExpression(string property, long value)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			return Expression.GreaterThan(expressionProperty, Expression.Constant(value));
		}

		private Expression BuildGreaterThanExpression(string property, DateTime value)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			ConstantExpression expressionValue = Expression.Constant(value.Date);
			return Expression.GreaterThan(Expression.Property(expressionProperty, "Date"), expressionValue);
		}

		private Expression BuildGreaterThanOrEqualExpression(string property, long value)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			return Expression.GreaterThanOrEqual(expressionProperty, Expression.Constant(value));
		}

		private Expression BuildGreaterThanOrEqualExpression(string property, DateTime value)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			ConstantExpression expressionValue = Expression.Constant(value.Date);
			return Expression.GreaterThanOrEqual(Expression.Property(expressionProperty, "Date"), expressionValue);
		}

		private Expression buildIntEqualsExpression(string property, long value)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			Type type = typeof(long);
			Type[] typeArray = new Type[] { typeof(long) };
			MethodInfo expressionMethod = type.GetMethod("Equals", typeArray);
			Expression[] expressionArray = new Expression[] { Expression.Constant(value) };
			return Expression.Call(expressionProperty, expressionMethod, expressionArray);
		}

		private Expression BuildLessThanExpression(string property, long value)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			return Expression.LessThan(expressionProperty, Expression.Constant(value));
		}

		private Expression BuildLessThanExpression(string property, DateTime value)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			ConstantExpression expressionValue = Expression.Constant(value.Date);
			return Expression.LessThan(Expression.Property(expressionProperty, "Date"), expressionValue);
		}

		private Expression BuildLessThanOrEqualExpression(string property, long value)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			return Expression.LessThanOrEqual(expressionProperty, Expression.Constant(value));
		}

		private Expression BuildLessThanOrEqualExpression(string property, DateTime value)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			ConstantExpression expressionValue = Expression.Constant(value.Date);
			return Expression.LessThanOrEqual(Expression.Property(expressionProperty, "Date"), expressionValue);
		}

		private Expression BuildNotContainsExpression(string property, string value)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			MethodInfo expressionMethod = typeof(string).GetMethod("Contains");
			Expression[] expressionArray = new Expression[] { Expression.Constant(value) };
			return Expression.Not(Expression.Call(expressionProperty, expressionMethod, expressionArray));
		}

		private Expression BuildNotEqualExpression(string property, string condition)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			MethodInfo expressionMethod = typeof(List<string>).GetMethod("Contains");
			Expression finalExpression = null;
			if (property == "Name" && condition == "AND")
			{
				ConstantExpression constantExpression = Expression.Constant(this.AndNameNotEqual);
				Expression[] expressionArray = new Expression[] { expressionProperty };
				finalExpression = Expression.Not(Expression.Call(constantExpression, expressionMethod, expressionArray));
			}
			else if (property == "DirectoryName" && condition == "AND")
			{
				ConstantExpression constantExpression1 = Expression.Constant(this.AndFullPathNotEqual);
				Expression[] expressionArray1 = new Expression[] { expressionProperty };
				finalExpression = Expression.Not(Expression.Call(constantExpression1, expressionMethod, expressionArray1));
			}
			else if (property == "Extension" && condition == "AND")
			{
				ConstantExpression constantExpression2 = Expression.Constant(this.AndExtensionNotEqual);
				Expression[] expressionArray2 = new Expression[] { expressionProperty };
				finalExpression = Expression.Not(Expression.Call(constantExpression2, expressionMethod, expressionArray2));
			}
			else if (property == "Name" && condition == "OR")
			{
				ConstantExpression constantExpression3 = Expression.Constant(this.OrNameNotEqual);
				Expression[] expressionArray3 = new Expression[] { expressionProperty };
				finalExpression = Expression.Not(Expression.Call(constantExpression3, expressionMethod, expressionArray3));
			}
			else if (property == "DirectoryName" && condition == "OR")
			{
				ConstantExpression constantExpression4 = Expression.Constant(this.OrFullPathNotEqual);
				Expression[] expressionArray4 = new Expression[] { expressionProperty };
				finalExpression = Expression.Not(Expression.Call(constantExpression4, expressionMethod, expressionArray4));
			}
			else if (property == "Extension" && condition == "OR")
			{
				ConstantExpression constantExpression5 = Expression.Constant(this.OrExtensionNotEqual);
				Expression[] expressionArray5 = new Expression[] { expressionProperty };
				finalExpression = Expression.Not(Expression.Call(constantExpression5, expressionMethod, expressionArray5));
			}
			return finalExpression;
		}

		private void CleanAndSeparateClauses(string sentence)
		{
			string sqlWhereClauseWithOutSimpleQuotes = Regex.Replace(sentence, "(?<=^([^']|'[^']*')*)(?<=^([^\"]|\"[^\"]*\")*)'", "\"");
			string SqlWhereClauseWithOutMultipleSpaces = Regex.Replace(sqlWhereClauseWithOutSimpleQuotes, "(?<=^([^\"]|\"[^\"]*\")*)[ ]{2,}", " ").Trim();
			string[] separatedClauses = Regex.Split(SqlWhereClauseWithOutMultipleSpaces, "(?<=^([^\"]|\"[^\"]*\")*)order by", RegexOptions.IgnoreCase);
			this.SqlWhereClause = separatedClauses[0].Trim();
			this.SqlWhereClause = Regex.Replace(this.SqlWhereClause, "(?<=^([^\"]|\"[^\"]*\")*)contains", "c?ontains", RegexOptions.IgnoreCase);
			this.SqlWhereClause = Regex.Replace(this.SqlWhereClause, "(?<=^([^\"]|\"[^\"]*\")*)!contains", "!c?ontains", RegexOptions.IgnoreCase);
			if (separatedClauses.Count<string>() == 3)
			{
				this.SqlOrderByClause = separatedClauses[2].Trim();
				return;
			}
			if (separatedClauses.Count<string>() > 3)
			{
				throw new ArgumentException("ORDER BY Clause not valid");
			}
		}

		private Expression CombineExpressions(Dictionary<string, Expression> expressionsToCombine)
		{
			Expression finalExpression = this.BuildAnAllwaysTrueExpression();
			foreach (KeyValuePair<string, Expression> exp in expressionsToCombine)
			{
				if (exp.Key == "AndNameEquals" || exp.Key == "AndFullPathEquals" || exp.Key == "AndExtensionEquals" || exp.Key == "AndNameNotEqual" || exp.Key == "AndFullPathNotEqual" || exp.Key == "AndExtensionNotEqual" || exp.Key.Contains("AndNameContains") || exp.Key.Contains("AndFullPathContains") || exp.Key.Contains("AndExtensionContains") || exp.Key.Contains("AndNameNotContains") || exp.Key.Contains("AndFullPathNotContains") || exp.Key.Contains("AndExtensionNotContains") || exp.Key.Contains("AndLenghtEquals") || exp.Key.Contains("AndGreaterThanEquals") || exp.Key.Contains("AndLessThanEquals") || exp.Key.Contains("AndGreaterThanOrEquals") || exp.Key.Contains("AndLessThanOrEquals") || exp.Key.Contains("AndCreationDateEquals") || exp.Key.Contains("AndCreationDateGreaterThanEquals") || exp.Key.Contains("AndCreationDateLessThanEquals") || exp.Key.Contains("AndCreationDateGreaterThanOrEquals") || exp.Key.Contains("AndCreationDateLessThanOrEquals") || exp.Key.Contains("AndModificationDateEquals") || exp.Key.Contains("AndModificationDateGreaterThanEquals") || exp.Key.Contains("AndModificationDateLessThanEquals") || exp.Key.Contains("AndModificationDateGreaterThanOrEquals") || exp.Key.Contains("AndModificationDateLessThanOrEquals"))
				{
					finalExpression = Expression.And(finalExpression, exp.Value);
				}
				else
				{
					if (!(exp.Key == "OrNameEquals") && !(exp.Key == "OrFullPathEquals") && !(exp.Key == "OrExtensionEquals") && !(exp.Key == "OrNameNotEqual") && !(exp.Key == "OrFullPathNotEqual") && !(exp.Key == "OrExtensionNotEqual") && !exp.Key.Contains("OrNameContains") && !exp.Key.Contains("OrFullPathContains") && !exp.Key.Contains("OrExtensionContains") && !exp.Key.Contains("OrNameNotContains") && !exp.Key.Contains("OrFullPathNotContains") && !exp.Key.Contains("OrExtensionNotContains") && !exp.Key.Contains("OrLenghtEquals") && !exp.Key.Contains("OrGreaterThanEquals") && !exp.Key.Contains("OrLessThanEquals") && !exp.Key.Contains("OrGreaterThanOrEquals") && !exp.Key.Contains("OrLessThanOrEquals") && !exp.Key.Contains("OrCreationDateEquals") && !exp.Key.Contains("OrCreationDateGreaterThanEquals") && !exp.Key.Contains("OrCreationDateLessThanEquals") && !exp.Key.Contains("OrCreationDateGreaterThanOrEquals") && !exp.Key.Contains("OrCreationDateLessThanOrEquals") && !exp.Key.Contains("OrModificationDateEquals") && !exp.Key.Contains("OrModificationDateGreaterThanEquals") && !exp.Key.Contains("OrModificationDateLessThanEquals") && !exp.Key.Contains("OrModificationDateGreaterThanOrEquals") && !exp.Key.Contains("OrModificationDateLessThanOrEquals"))
					{
						continue;
					}
					finalExpression = Expression.Or(finalExpression, exp.Value);
				}
			}
			return finalExpression;
		}

		private void EvaluateAndConditions(List<string> andParameters)
		{
			foreach (string andParam in andParameters)
			{
				this.FillDataAccordingPropetyAndOperator(this.GetProperty(andParam), this.GetOperator(andParam), this.GetValue(andParam), "AND");
			}
		}

		private void EvaluateOrConditions(List<string> orParameters)
		{
			foreach (string orParam in orParameters)
			{
				this.FillDataAccordingPropetyAndOperator(this.GetProperty(orParam), this.GetOperator(orParam), this.GetValue(orParam), "OR");
			}
		}

		private void FillDataAccordingPropetyAndOperator(string param, string anOperator, string value, string conditional)
		{
			if (conditional != "AND")
			{
				if (conditional == "OR")
				{
					if (anOperator == "Equal")
					{
						if (param.ToLower() == "Name".ToLower())
						{
							this.OrNameEquals.Add(value.Replace("\"", ""));
							return;
						}
						if (param.ToLower() == "DirectoryName".ToLower())
						{
							this.OrFullPathEquals.Add(value.Replace("\"", ""));
							return;
						}
						if (param.ToLower() == "Extension".ToLower())
						{
							this.OrExtensionEquals.Add(value.Replace("\"", ""));
							return;
						}
						if (param.ToLower() == "Length".ToLower())
						{
							this.OrLenghtEquals.Add(value);
							return;
						}
						if (param.ToLower() == "CreationDate".ToLower())
						{
							this.OrCreationTimeEquals.Add(value);
							return;
						}
						if (param.ToLower() == "ModificationDate".ToLower())
						{
							this.OrLastWriteTimeEquals.Add(value);
							return;
						}
					}
					else if (anOperator == "NotEqual")
					{
						if (param.ToLower() == "Name".ToLower())
						{
							this.OrNameNotEqual.Add(value.Replace("\"", ""));
							return;
						}
						if (param.ToLower() == "DirectoryName".ToLower())
						{
							this.OrFullPathNotEqual.Add(value.Replace("\"", ""));
							return;
						}
						if (param.ToLower() == "Extension".ToLower())
						{
							this.OrExtensionNotEqual.Add(value.Replace("\"", ""));
							return;
						}
					}
					else if (anOperator == "Contains")
					{
						if (param.ToLower() == "Name".ToLower())
						{
							this.OrNameContains.Add(value.Replace("\"", ""));
							return;
						}
						if (param.ToLower() == "DirectoryName".ToLower())
						{
							this.OrFullPathContains.Add(value.Replace("\"", ""));
							return;
						}
						if (param.ToLower() == "Extension".ToLower())
						{
							this.OrExtensionContains.Add(value.Replace("\"", ""));
							return;
						}
					}
					else if (anOperator == "NotContains")
					{
						if (param.ToLower() == "Name".ToLower())
						{
							this.OrNameNotContains.Add(value.Replace("\"", ""));
							return;
						}
						if (param.ToLower() == "DirectoryName".ToLower())
						{
							this.OrFullPathNotContains.Add(value.Replace("\"", ""));
							return;
						}
						if (param.ToLower() == "Extension".ToLower())
						{
							this.OrExtensionNotContains.Add(value.Replace("\"", ""));
							return;
						}
					}
					else if (anOperator == "GreatherThan")
					{
						if (param.ToLower() == "Length".ToLower())
						{
							this.OrLenghtGreaterThan.Add(value);
						}
						if (param.ToLower() == "CreationDate".ToLower())
						{
							this.OrCreationTimeGreaterThan.Add(value);
						}
						if (param.ToLower() == "ModificationDate".ToLower())
						{
							this.OrLastWriteTimeGreaterThan.Add(value);
							return;
						}
					}
					else if (anOperator == "LessThan")
					{
						if (param.ToLower() == "Length".ToLower())
						{
							this.OrLenghtLessThan.Add(value);
						}
						if (param.ToLower() == "CreationDate".ToLower())
						{
							this.OrCreationTimeLessThan.Add(value);
						}
						if (param.ToLower() == "ModificationDate".ToLower())
						{
							this.OrLastWriteTimeLessThan.Add(value);
							return;
						}
					}
					else if (anOperator == "GreatherThanOrEqual")
					{
						if (param.ToLower() == "Length".ToLower())
						{
							this.OrLenghtGreaterThanOrEqual.Add(value);
						}
						if (param.ToLower() == "CreationDate".ToLower())
						{
							this.OrCreationTimeGreaterThanOrEqual.Add(value);
						}
						if (param.ToLower() == "ModificationDate".ToLower())
						{
							this.OrLastWriteTimeGreaterThanOrEqual.Add(value);
							return;
						}
					}
					else if (anOperator == "LessThanOrEqual")
					{
						if (param.ToLower() == "Length".ToLower())
						{
							this.OrLenghtLessThanOrEqual.Add(value);
						}
						if (param.ToLower() == "CreationDate".ToLower())
						{
							this.OrCreationTimeLessThanOrEqual.Add(value);
						}
						if (param.ToLower() == "ModificationDate".ToLower())
						{
							this.OrLastWriteTimeLessThanOrEqual.Add(value);
						}
					}
				}
			}
			else if (anOperator == "Equal")
			{
				if (param.ToLower() == "Name".ToLower())
				{
					this.AndNameEquals.Add(value.Replace("\"", ""));
					return;
				}
				if (param.ToLower() == "DirectoryName".ToLower())
				{
					this.AndFullPathEquals.Add(value.Replace("\"", ""));
					return;
				}
				if (param.ToLower() == "Extension".ToLower())
				{
					this.AndExtensionEquals.Add(value.Replace("\"", ""));
					return;
				}
				if (param.ToLower() == "Length".ToLower())
				{
					this.AndLenghtEquals.Add(value);
					return;
				}
				if (param.ToLower() == "CreationDate".ToLower())
				{
					this.AndCreationTimeEquals.Add(value);
					return;
				}
				if (param.ToLower() == "ModificationDate".ToLower())
				{
					this.AndLastWriteTimeEquals.Add(value);
					return;
				}
			}
			else if (anOperator == "NotEqual")
			{
				if (param.ToLower() == "Name".ToLower())
				{
					this.AndNameNotEqual.Add(value.Replace("\"", ""));
					return;
				}
				if (param.ToLower() == "DirectoryName".ToLower())
				{
					this.AndFullPathNotEqual.Add(value.Replace("\"", ""));
					return;
				}
				if (param.ToLower() == "Extension".ToLower())
				{
					this.AndExtensionNotEqual.Add(value.Replace("\"", ""));
					return;
				}
			}
			else if (anOperator == "Contains")
			{
				if (param.ToLower() == "Name".ToLower())
				{
					this.AndNameContains.Add(value.Replace("\"", ""));
					return;
				}
				if (param.ToLower() == "DirectoryName".ToLower())
				{
					this.AndFullPathContains.Add(value.Replace("\"", ""));
					return;
				}
				if (param.ToLower() == "Extension".ToLower())
				{
					this.AndExtensionContains.Add(value.Replace("\"", ""));
					return;
				}
			}
			else if (anOperator.ToLower() == "NotContains".ToLower())
			{
				if (param.ToLower() == "Name".ToLower())
				{
					this.AndNameNotContains.Add(value.Replace("\"", ""));
					return;
				}
				if (param.ToLower() == "DirectoryName".ToLower())
				{
					this.AndFullPathNotContains.Add(value.Replace("\"", ""));
					return;
				}
				if (param.ToLower() == "Extension".ToLower())
				{
					this.AndExtensionNotContains.Add(value.Replace("\"", ""));
					return;
				}
			}
			else if (anOperator == "GreatherThan")
			{
				if (param.ToLower() == "Length".ToLower())
				{
					this.AndLenghtGreaterThan.Add(value);
				}
				if (param.ToLower() == "CreationDate".ToLower())
				{
					this.AndCreationTimeGreaterThan.Add(value);
				}
				if (param.ToLower() == "ModificationDate".ToLower())
				{
					this.AndLastWriteTimeGreaterThan.Add(value);
					return;
				}
			}
			else if (anOperator == "LessThan")
			{
				if (param.ToLower() == "Length".ToLower())
				{
					this.AndLenghtLessThan.Add(value);
				}
				if (param.ToLower() == "CreationDate".ToLower())
				{
					this.AndCreationTimeLessThan.Add(value);
				}
				if (param.ToLower() == "ModificationDate".ToLower())
				{
					this.AndLastWriteTimeLessThan.Add(value);
					return;
				}
			}
			else if (anOperator == "GreatherThanOrEqual")
			{
				if (param.ToLower() == "Length".ToLower())
				{
					this.AndLenghtGreaterThanOrEqual.Add(value);
				}
				if (param.ToLower() == "CreationDate".ToLower())
				{
					this.AndCreationTimeGreaterThanOrEqual.Add(value);
				}
				if (param.ToLower() == "ModificationDate".ToLower())
				{
					this.AndLastWriteTimeGreaterThanOrEqual.Add(value);
					return;
				}
			}
			else if (anOperator == "LessThanOrEqual")
			{
				if (param.ToLower() == "Length".ToLower())
				{
					this.AndLenghtLessThanOrEqual.Add(value);
				}
				if (param.ToLower() == "CreationDate".ToLower())
				{
					this.AndCreationTimeLessThanOrEqual.Add(value);
				}
				if (param.ToLower() == "ModificationDate".ToLower())
				{
					this.AndLastWriteTimeLessThanOrEqual.Add(value);
					return;
				}
			}
		}

		private string GetOperator(string condition)
		{
			if (condition.ToLower().IndexOf(">=") > 0)
			{
				return "GreatherThanOrEqual";
			}
			if (condition.ToLower().IndexOf("<=") > 0)
			{
				return "LessThanOrEqual";
			}
			if (condition.IndexOf("=") > 0)
			{
				return "Equal";
			}
			if (condition.IndexOf("<>") > 0)
			{
				return "NotEqual";
			}
			if (condition.ToLower().IndexOf("!c?ontains") > 0)
			{
				return "NotContains";
			}
			if (condition.ToLower().IndexOf("c?ontains") > 0)
			{
				return "Contains";
			}
			if (condition.ToLower().IndexOf(">") > 0)
			{
				return "GreatherThan";
			}
			if (condition.ToLower().IndexOf("<") > 0)
			{
				return "LessThan";
			}
			return null;
		}

		private Dictionary<string, string> GetOrderPropertiesAndDirection(string orderByClause)
		{
			Dictionary<string, string> strs;
			try
			{
				strs = this.ValidateOrderByClause(orderByClause);
			}
			catch (ArgumentException argumentException)
			{
				ArgumentException e = argumentException;
				Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
				throw e;
			}
			return strs;
		}

		private string GetProperty(string condition)
		{
			string[] splitedCondition = this.SplitParametersByOperator(condition);
			if (splitedCondition.Count<string>() != 2)
			{
				return null;
			}
			return splitedCondition[0];
		}

		private string GetValue(string condition)
		{
			string[] splitedCondition = this.SplitParametersByOperator(condition);
			if (splitedCondition.Count<string>() != 2)
			{
				return null;
			}
			return splitedCondition[1];
		}

		private Func<FileInfo, DateTime> MakeOrderByLambdaClauseForDateTimeProperty(string property)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			ParameterExpression[] expressionParameter = new ParameterExpression[] { this.ExpressionParameter };
			return Expression.Lambda<Func<FileInfo, DateTime>>(expressionProperty, expressionParameter).Compile();
		}

		private Func<FileInfo, long> MakeOrderByLambdaClauseForIntProperty(string property)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			ParameterExpression[] expressionParameter = new ParameterExpression[] { this.ExpressionParameter };
			return Expression.Lambda<Func<FileInfo, long>>(expressionProperty, expressionParameter).Compile();
		}

		private Func<FileInfo, string> MakeOrderByLambdaClauseForStringProperty(string property)
		{
			MemberExpression expressionProperty = Expression.Property(this.ExpressionParameter, typeof(FileInfo).GetProperty(property));
			ParameterExpression[] expressionParameter = new ParameterExpression[] { this.ExpressionParameter };
			return Expression.Lambda<Func<FileInfo, string>>(expressionProperty, expressionParameter).Compile();
		}

		private Func<FileInfo, bool> MakeWhereLambdaClause()
		{
			Dictionary<string, Expression> expressionsList = new Dictionary<string, Expression>();
			if (this.AndNameEquals.Count > 0)
			{
				expressionsList.Add("AndNameEquals", this.BuildEqualsExpression("Name", "AND"));
			}
			if (this.AndFullPathEquals.Count > 0)
			{
				expressionsList.Add("AndFullPathEquals", this.BuildEqualsExpression("DirectoryName", "AND"));
			}
			if (this.AndExtensionEquals.Count > 0)
			{
				expressionsList.Add("AndExtensionEquals", this.BuildEqualsExpression("Extension", "AND"));
			}
			if (this.AndNameNotEqual.Count > 0)
			{
				expressionsList.Add("AndNameNotEqual", this.BuildNotEqualExpression("Name", "AND"));
			}
			if (this.AndFullPathNotEqual.Count > 0)
			{
				expressionsList.Add("AndFullPathNotEqual", this.BuildNotEqualExpression("DirectoryName", "AND"));
			}
			if (this.AndExtensionNotEqual.Count > 0)
			{
				expressionsList.Add("AndExtensionNotEqual", this.BuildNotEqualExpression("Extension", "AND"));
			}
			if (this.AndNameContains.Count > 0)
			{
				foreach (string value in this.AndNameContains)
				{
					expressionsList.Add(string.Concat("AndNameContains", value), this.BuildContainsExpression("Name", value));
				}
			}
			if (this.AndFullPathContains.Count > 0)
			{
				foreach (string value in this.AndFullPathContains)
				{
					expressionsList.Add(string.Concat("AndFullPathContains", value), this.BuildContainsExpression("DirectoryName", value));
				}
			}
			if (this.AndExtensionContains.Count > 0)
			{
				foreach (string value in this.AndExtensionContains)
				{
					expressionsList.Add(string.Concat("AndExtensionContains", value), this.BuildContainsExpression("Extension", value));
				}
			}
			if (this.AndNameNotContains.Count > 0)
			{
				foreach (string value in this.AndNameNotContains)
				{
					expressionsList.Add(string.Concat("AndNameNotContains", value), this.BuildNotContainsExpression("Name", value));
				}
			}
			if (this.AndFullPathNotContains.Count > 0)
			{
				foreach (string value in this.AndFullPathNotContains)
				{
					expressionsList.Add(string.Concat("AndFullPathNotContains", value), this.BuildNotContainsExpression("DirectoryName", value));
				}
			}
			if (this.AndExtensionNotContains.Count > 0)
			{
				foreach (string value in this.AndExtensionNotContains)
				{
					expressionsList.Add(string.Concat("AndExtensionNotContains", value), this.BuildNotContainsExpression("Extension", value));
				}
			}
			if (this.AndLenghtEquals.Count > 0)
			{
				foreach (string value in this.AndLenghtEquals)
				{
					expressionsList.Add(string.Concat("AndLenghtEquals", value), this.buildIntEqualsExpression("Length", Convert.ToInt64(value)));
				}
			}
			if (this.AndLenghtGreaterThan.Count > 0)
			{
				foreach (string value in this.AndLenghtGreaterThan)
				{
					expressionsList.Add(string.Concat("AndGreaterThanEquals", value), this.BuildGreaterThanExpression("Length", Convert.ToInt64(value)));
				}
			}
			if (this.AndLenghtLessThan.Count > 0)
			{
				foreach (string value in this.AndLenghtLessThan)
				{
					expressionsList.Add(string.Concat("AndLessThanEquals", value), this.BuildLessThanExpression("Length", Convert.ToInt64(value)));
				}
			}
			if (this.AndLenghtGreaterThanOrEqual.Count > 0)
			{
				foreach (string value in this.AndLenghtGreaterThanOrEqual)
				{
					expressionsList.Add(string.Concat("AndGreaterThanOrEquals", value), this.BuildGreaterThanOrEqualExpression("Length", Convert.ToInt64(value)));
				}
			}
			if (this.AndLenghtLessThanOrEqual.Count > 0)
			{
				foreach (string value in this.AndLenghtLessThanOrEqual)
				{
					expressionsList.Add(string.Concat("AndLessThanOrEquals", value), this.BuildLessThanOrEqualExpression("Length", Convert.ToInt64(value)));
				}
			}
			if (this.AndCreationTimeEquals.Count > 0)
			{
				foreach (string value in this.AndCreationTimeEquals)
				{
					expressionsList.Add(string.Concat("AndCreationDateEquals", value), this.buildDateEqualsExpression("CreationTime", Convert.ToDateTime(value)));
				}
			}
			if (this.AndCreationTimeGreaterThan.Count > 0)
			{
				foreach (string value in this.AndCreationTimeGreaterThan)
				{
					expressionsList.Add(string.Concat("AndCreationDateGreaterThanEquals", value), this.BuildGreaterThanExpression("CreationTime", Convert.ToDateTime(value)));
				}
			}
			if (this.AndCreationTimeLessThan.Count > 0)
			{
				foreach (string value in this.AndCreationTimeLessThan)
				{
					expressionsList.Add(string.Concat("AndCreationDateLessThanEquals", value), this.BuildLessThanExpression("CreationTime", Convert.ToDateTime(value)));
				}
			}
			if (this.AndCreationTimeGreaterThanOrEqual.Count > 0)
			{
				foreach (string value in this.AndCreationTimeGreaterThanOrEqual)
				{
					expressionsList.Add(string.Concat("AndCreationDateGreaterThanOrEquals", value), this.BuildGreaterThanOrEqualExpression("CreationTime", Convert.ToDateTime(value)));
				}
			}
			if (this.AndCreationTimeLessThanOrEqual.Count > 0)
			{
				foreach (string value in this.AndCreationTimeLessThanOrEqual)
				{
					expressionsList.Add(string.Concat("AndCreationDateLessThanOrEquals", value), this.BuildLessThanOrEqualExpression("CreationTime", Convert.ToDateTime(value)));
				}
			}
			if (this.AndLastWriteTimeEquals.Count > 0)
			{
				foreach (string value in this.AndLastWriteTimeEquals)
				{
					expressionsList.Add(string.Concat("AndModificationDateEquals", value), this.buildDateEqualsExpression("LastWriteTime", Convert.ToDateTime(value)));
				}
			}
			if (this.AndLastWriteTimeGreaterThan.Count > 0)
			{
				foreach (string value in this.AndLastWriteTimeGreaterThan)
				{
					expressionsList.Add(string.Concat("AndModificationDateGreaterThanEquals", value), this.BuildGreaterThanExpression("LastWriteTime", Convert.ToDateTime(value)));
				}
			}
			if (this.AndLastWriteTimeLessThan.Count > 0)
			{
				foreach (string value in this.AndLastWriteTimeLessThan)
				{
					expressionsList.Add(string.Concat("AndModificationDateLessThanEquals", value), this.BuildLessThanExpression("LastWriteTime", Convert.ToDateTime(value)));
				}
			}
			if (this.AndLastWriteTimeGreaterThanOrEqual.Count > 0)
			{
				foreach (string value in this.AndLastWriteTimeGreaterThanOrEqual)
				{
					expressionsList.Add(string.Concat("AndModificationDateGreaterThanOrEquals", value), this.BuildGreaterThanOrEqualExpression("LastWriteTime", Convert.ToDateTime(value)));
				}
			}
			if (this.AndLastWriteTimeLessThanOrEqual.Count > 0)
			{
				foreach (string value in this.AndLastWriteTimeLessThanOrEqual)
				{
					expressionsList.Add(string.Concat("AndModificationDateLessThanOrEquals", value), this.BuildLessThanOrEqualExpression("LastWriteTime", Convert.ToDateTime(value)));
				}
			}
			if (this.OrNameEquals.Count > 0)
			{
				expressionsList.Add("OrNameEquals", this.BuildEqualsExpression("Name", "OR"));
			}
			if (this.OrFullPathEquals.Count > 0)
			{
				expressionsList.Add("OrFullPathEquals", this.BuildEqualsExpression("DirectoryName", "OR"));
			}
			if (this.OrExtensionEquals.Count > 0)
			{
				expressionsList.Add("OrExtensionEquals", this.BuildEqualsExpression("Extension", "OR"));
			}
			if (this.OrNameNotEqual.Count > 0)
			{
				expressionsList.Add("OrNameNotEqual", this.BuildNotEqualExpression("Name", "OR"));
			}
			if (this.OrFullPathNotEqual.Count > 0)
			{
				expressionsList.Add("OrFullPathNotEqual", this.BuildNotEqualExpression("DirectoryName", "OR"));
			}
			if (this.OrExtensionNotEqual.Count > 0)
			{
				expressionsList.Add("OrExtensionNotEqual", this.BuildNotEqualExpression("Extension", "OR"));
			}
			if (this.OrNameContains.Count > 0)
			{
				foreach (string value in this.OrNameContains)
				{
					expressionsList.Add(string.Concat("OrNameContains", value), this.BuildContainsExpression("Name", value));
				}
			}
			if (this.OrFullPathContains.Count > 0)
			{
				foreach (string value in this.OrFullPathContains)
				{
					expressionsList.Add(string.Concat("OrFullPathContains", value), this.BuildContainsExpression("DirectoryName", value));
				}
			}
			if (this.OrExtensionContains.Count > 0)
			{
				foreach (string value in this.OrExtensionContains)
				{
					expressionsList.Add(string.Concat("OrExtensionContains", value), this.BuildContainsExpression("Extension", value));
				}
			}
			if (this.OrNameNotContains.Count > 0)
			{
				foreach (string value in this.OrNameNotContains)
				{
					expressionsList.Add(string.Concat("OrNameNotContains", value), this.BuildNotContainsExpression("Name", value));
				}
			}
			if (this.OrFullPathNotContains.Count > 0)
			{
				foreach (string value in this.OrFullPathNotContains)
				{
					expressionsList.Add(string.Concat("OrFullPathNotContains", value), this.BuildNotContainsExpression("DirectoryName", value));
				}
			}
			if (this.OrExtensionNotContains.Count > 0)
			{
				foreach (string value in this.OrExtensionNotContains)
				{
					expressionsList.Add(string.Concat("OrExtensionNotContains", value), this.BuildNotContainsExpression("Extension", value));
				}
			}
			if (this.OrLenghtEquals.Count > 0)
			{
				foreach (string value in this.OrLenghtEquals)
				{
					expressionsList.Add(string.Concat("OrLenghtEquals", value), this.buildIntEqualsExpression("Length", Convert.ToInt64(value)));
				}
			}
			if (this.OrLenghtGreaterThan.Count > 0)
			{
				foreach (string value in this.OrLenghtGreaterThan)
				{
					expressionsList.Add(string.Concat("OrGreaterThanEquals", value), this.BuildGreaterThanExpression("Length", Convert.ToInt64(value)));
				}
			}
			if (this.OrLenghtLessThan.Count > 0)
			{
				foreach (string value in this.OrLenghtLessThan)
				{
					expressionsList.Add(string.Concat("OrLessThanEquals", value), this.BuildLessThanExpression("Length", Convert.ToInt64(value)));
				}
			}
			if (this.OrLenghtGreaterThanOrEqual.Count > 0)
			{
				foreach (string value in this.OrLenghtGreaterThanOrEqual)
				{
					expressionsList.Add(string.Concat("OrGreaterThanOrEquals", value), this.BuildGreaterThanOrEqualExpression("Length", Convert.ToInt64(value)));
				}
			}
			if (this.OrLenghtLessThanOrEqual.Count > 0)
			{
				foreach (string value in this.OrLenghtLessThanOrEqual)
				{
					expressionsList.Add(string.Concat("OrLessThanOrEquals", value), this.BuildLessThanOrEqualExpression("Length", Convert.ToInt64(value)));
				}
			}
			if (this.OrCreationTimeEquals.Count > 0)
			{
				foreach (string value in this.OrCreationTimeEquals)
				{
					expressionsList.Add(string.Concat("OrCreationDateEquals", value), this.buildDateEqualsExpression("CreationTime", Convert.ToDateTime(value)));
				}
			}
			if (this.OrCreationTimeGreaterThan.Count > 0)
			{
				foreach (string value in this.OrCreationTimeGreaterThan)
				{
					expressionsList.Add(string.Concat("OrCreationDateGreaterThanEquals", value), this.BuildGreaterThanExpression("CreationTime", Convert.ToDateTime(value)));
				}
			}
			if (this.OrCreationTimeLessThan.Count > 0)
			{
				foreach (string value in this.OrCreationTimeLessThan)
				{
					expressionsList.Add(string.Concat("OrCreationDateLessThanEquals", value), this.BuildLessThanExpression("CreationTime", Convert.ToDateTime(value)));
				}
			}
			if (this.OrCreationTimeGreaterThanOrEqual.Count > 0)
			{
				foreach (string value in this.OrCreationTimeGreaterThanOrEqual)
				{
					expressionsList.Add(string.Concat("OrCreationDateGreaterThanOrEquals", value), this.BuildGreaterThanOrEqualExpression("CreationTime", Convert.ToDateTime(value)));
				}
			}
			if (this.OrCreationTimeLessThanOrEqual.Count > 0)
			{
				foreach (string value in this.OrCreationTimeLessThanOrEqual)
				{
					expressionsList.Add(string.Concat("OrCreationDateLessThanOrEquals", value), this.BuildLessThanOrEqualExpression("CreationTime", Convert.ToDateTime(value)));
				}
			}
			if (this.OrLastWriteTimeEquals.Count > 0)
			{
				foreach (string value in this.OrLastWriteTimeEquals)
				{
					expressionsList.Add(string.Concat("OrModificationDateEquals", value), this.buildDateEqualsExpression("LastWriteTime", Convert.ToDateTime(value)));
				}
			}
			if (this.OrLastWriteTimeGreaterThan.Count > 0)
			{
				foreach (string value in this.OrLastWriteTimeGreaterThan)
				{
					expressionsList.Add(string.Concat("OrModificationDateGreaterThanEquals", value), this.BuildGreaterThanExpression("LastWriteTime", Convert.ToDateTime(value)));
				}
			}
			if (this.OrLastWriteTimeLessThan.Count > 0)
			{
				foreach (string value in this.OrLastWriteTimeLessThan)
				{
					expressionsList.Add(string.Concat("OrModificationDateLessThanEquals", value), this.BuildLessThanExpression("LastWriteTime", Convert.ToDateTime(value)));
				}
			}
			if (this.OrLastWriteTimeGreaterThanOrEqual.Count > 0)
			{
				foreach (string value in this.OrLastWriteTimeGreaterThanOrEqual)
				{
					expressionsList.Add(string.Concat("OrModificationDateGreaterThanOrEquals", value), this.BuildGreaterThanOrEqualExpression("LastWriteTime", Convert.ToDateTime(value)));
				}
			}
			if (this.OrLastWriteTimeLessThanOrEqual.Count > 0)
			{
				foreach (string value in this.OrLastWriteTimeLessThanOrEqual)
				{
					expressionsList.Add(string.Concat("OrModificationDateLessThanOrEquals", value), this.BuildLessThanOrEqualExpression("LastWriteTime", Convert.ToDateTime(value)));
				}
			}
			Expression expression = this.CombineExpressions(expressionsList);
			ParameterExpression[] expressionParameter = new ParameterExpression[] { this.ExpressionParameter };
			return Expression.Lambda<Func<FileInfo, bool>>(expression, expressionParameter).Compile();
		}

		private void ParserSqlWhereClause()
		{
			string[] strArrays = new string[] { " AND ", " and ", " And ", " aNd ", " anD ", " AnD ", " aND ", " ANd ", " OR ", " or ", " Or ", " oR " };
			string[] andOrConditions = strArrays;
			string[] whereParameters = null;
			List<string> andParameters = new List<string>();
			List<string> orParameters = new List<string>();
			whereParameters = this.SqlWhereClause.Split(andOrConditions, StringSplitOptions.RemoveEmptyEntries);
			try
			{
				this.validateWhereParameters(whereParameters);
			}
			catch (ArgumentException argumentException)
			{
				ArgumentException e = argumentException;
				Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
				throw e;
			}
			string[] whereConditions = this.SqlWhereClause.Split(whereParameters, StringSplitOptions.RemoveEmptyEntries);
			foreach (var str in whereParameters.Select((string value, int index) => new { @value = value, index = index }))
			{
				int num = str.index;
				if (num != 0)
				{
					string conditional = whereConditions[num - 1];
					if (conditional.ToUpper().Trim() != "AND")
					{
						if (conditional.ToUpper().Trim() != "OR")
						{
							continue;
						}
						orParameters.Add(str.@value);
					}
					else
					{
						andParameters.Add(str.@value);
					}
				}
				else
				{
					andParameters.Add(str.@value);
				}
			}
			this.EvaluateAndConditions(andParameters);
			this.EvaluateOrConditions(orParameters);
		}

		public List<FileInfo> SelectFiles(List<FileInfo> files, string whereClause)
		{
			this.CleanAndSeparateClauses(whereClause);
			Log.WriteLog(string.Concat("WHERE: ", this.SqlWhereClause), "Log", this.GetType().Name, this.AppConfig);
			Log.WriteLog(string.Concat("ORDER BY: ", this.SqlOrderByClause), "Log", this.GetType().Name, this.AppConfig);
			try
			{
				this.ParserSqlWhereClause();
			}
			catch (ArgumentException argumentException)
			{
				ArgumentException e = argumentException;
				Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
				throw e;
			}
			IEnumerable<FileInfo> query = (
				from fi in files
				select fi).Where<FileInfo>(this.MakeWhereLambdaClause());
			IOrderedEnumerable<FileInfo> orderedQuery =
				from fi in query
				orderby 0
				select fi;
			Dictionary<string, string> orderPropertiesAndDirection = new Dictionary<string, string>();
			if (this.SqlOrderByClause != null && this.SqlOrderByClause != string.Empty)
			{
				orderPropertiesAndDirection = this.GetOrderPropertiesAndDirection(this.SqlOrderByClause);
			}
			foreach (KeyValuePair<string, string> prop in orderPropertiesAndDirection)
			{
				if (prop.Key == "Name" || prop.Key == "DirectoryName")
				{
					if (prop.Value != "ASC")
					{
						if (prop.Value != "DESC")
						{
							continue;
						}
						orderedQuery = orderedQuery.ThenByDescending<FileInfo, string>(this.MakeOrderByLambdaClauseForStringProperty(prop.Key));
					}
					else
					{
						orderedQuery = orderedQuery.ThenBy<FileInfo, string>(this.MakeOrderByLambdaClauseForStringProperty(prop.Key));
					}
				}
				else if (prop.Key == "Length")
				{
					if (prop.Value != "ASC")
					{
						if (prop.Value != "DESC")
						{
							continue;
						}
						orderedQuery = orderedQuery.ThenByDescending<FileInfo, long>(this.MakeOrderByLambdaClauseForIntProperty(prop.Key));
					}
					else
					{
						orderedQuery = orderedQuery.ThenBy<FileInfo, long>(this.MakeOrderByLambdaClauseForIntProperty(prop.Key));
					}
				}
				else if (prop.Key != "CreationTime")
				{
					if (prop.Key != "LastWriteTime")
					{
						continue;
					}
					if (prop.Value != "ASC")
					{
						if (prop.Value != "DESC")
						{
							continue;
						}
						orderedQuery = orderedQuery.ThenByDescending<FileInfo, DateTime>(this.MakeOrderByLambdaClauseForDateTimeProperty(prop.Key));
					}
					else
					{
						orderedQuery = orderedQuery.ThenBy<FileInfo, DateTime>(this.MakeOrderByLambdaClauseForDateTimeProperty(prop.Key));
					}
				}
				else if (prop.Value != "ASC")
				{
					if (prop.Value != "DESC")
					{
						continue;
					}
					orderedQuery = orderedQuery.ThenByDescending<FileInfo, DateTime>(this.MakeOrderByLambdaClauseForDateTimeProperty(prop.Key));
				}
				else
				{
					orderedQuery = orderedQuery.ThenBy<FileInfo, DateTime>(this.MakeOrderByLambdaClauseForDateTimeProperty(prop.Key));
				}
			}
			return orderedQuery.ToList<FileInfo>();
		}

		private string[] SplitParametersByOperator(string parameter)
		{
			string[] strArrays = new string[] { "=", " = ", "<>", " <> ", ">", " > ", "<", " < ", ">=", " >= ", "<=", " <= ", "c?ontains", " c?ontains ", "!c?ontains", " !c?ontains " };
			return parameter.Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
		}

		private Dictionary<string, string> ValidateOrderByClause(string orderByClause)
		{
			Dictionary<string, string> orderPropertiesAndDirection = new Dictionary<string, string>();
			string[] strArrays = orderByClause.Split(new char[] { ',' });
			for (int i = 0; i < (int)strArrays.Length; i++)
			{
				string orderParam = strArrays[i];
				if (orderParam.ToLower().Trim() == string.Concat("Name".ToLower(), " ", "DESC".ToLower()))
				{
					orderPropertiesAndDirection.Add("Name", "DESC");
				}
				else if (orderParam.ToLower().Trim() == string.Concat("DirectoryName".ToLower(), " ", "DESC".ToLower()))
				{
					orderPropertiesAndDirection.Add("DirectoryName", "DESC");
				}
				else if (orderParam.ToLower().Trim() == string.Concat("CreationDate".ToLower(), " ", "DESC".ToLower()))
				{
					orderPropertiesAndDirection.Add("CreationTime", "DESC");
				}
				else if (orderParam.ToLower().Trim() == string.Concat("ModificationDate".ToLower(), " ", "DESC".ToLower()))
				{
					orderPropertiesAndDirection.Add("LastWriteTime", "DESC");
				}
				else if (orderParam.ToLower().Trim() == string.Concat("Length".ToLower(), " ", "DESC".ToLower()))
				{
					orderPropertiesAndDirection.Add("Length", "DESC");
				}
				else if (orderParam.ToLower().Trim() == "Name".ToLower() || orderParam.ToLower().Trim() == string.Concat("Name".ToLower(), " ", "ASC".ToLower()))
				{
					orderPropertiesAndDirection.Add("Name", "ASC");
				}
				else if (orderParam.ToLower().Trim() == "DirectoryName".ToLower() || orderParam.ToLower().Trim() == string.Concat("DirectoryName".ToLower(), " ", "ASC".ToLower()))
				{
					orderPropertiesAndDirection.Add("DirectoryName", "ASC");
				}
				else if (orderParam.ToLower().Trim() == "CreationDate".ToLower() || orderParam.ToLower().Trim() == string.Concat("CreationDate".ToLower(), " ", "ASC".ToLower()))
				{
					orderPropertiesAndDirection.Add("CreationTime", "ASC");
				}
				else if (orderParam.ToLower().Trim() == "ModificationDate".ToLower() || orderParam.ToLower().Trim() == string.Concat("ModificationDate".ToLower(), " ", "ASC".ToLower()))
				{
					orderPropertiesAndDirection.Add("LastWriteTime", "ASC");
				}
				else
				{
					if (!(orderParam.ToLower().Trim() == "Length".ToLower()) && !(orderParam.ToLower().Trim() == string.Concat("Length".ToLower(), " ", "ASC".ToLower())))
					{
						throw new ArgumentException("ORDER BY Clause is not valid");
					}
					orderPropertiesAndDirection.Add("Length", "ASC");
				}
			}
			return orderPropertiesAndDirection;
		}

		private void ValidateParametersNameAndValue(string parameterName, string parameterValue)
		{
			if (parameterName.ToLower() == "Name".ToLower() || parameterName.ToLower() == "DirectoryName".ToLower() || parameterName.ToLower() == "Extension".ToLower())
			{
				if (!parameterValue.StartsWith("\"") && !parameterValue.EndsWith("\""))
				{
					throw new ArgumentException("String Value Or Operator Not Valid");
				}
			}
			else if (parameterName.ToLower() == "Length".ToLower())
			{
				long intValue = (long)0;
				if (!long.TryParse(parameterValue, out intValue))
				{
					throw new ArgumentException("Integer Value Or Operator Not Valid");
				}
			}
			else if (parameterName.ToLower() != "CreationDate".ToLower())
			{
				if (parameterName.ToLower() != "ModificationDate".ToLower())
				{
					throw new ArgumentException("Property Name Or Operator Not Valid");
				}
				DateTime dateTimeValue = new DateTime(2015, 1, 1);
				if (!DateTime.TryParse(parameterValue, out dateTimeValue))
				{
					throw new ArgumentException("Date Value Or Operator Not Valid");
				}
			}
			else
			{
				DateTime dateTimeValue = new DateTime(2015, 1, 1);
				if (!DateTime.TryParse(parameterValue, out dateTimeValue))
				{
					throw new ArgumentException("Date Value Or Operator Not Valid");
				}
			}
		}

		private void validateWhereParameters(string[] whereParameters)
		{
			string[] strArrays = whereParameters;
			for (int i = 0; i < (int)strArrays.Length; i++)
			{
				string[] nameAndValueParameters = this.SplitParametersByOperator(strArrays[i]);
				if (nameAndValueParameters.Count<string>() != 2)
				{
					throw new ArgumentException("Logical Operator Not Valid");
				}
				try
				{
					this.ValidateParametersNameAndValue(nameAndValueParameters[0].Trim(), nameAndValueParameters[1].Trim());
				}
				catch (ArgumentException argumentException)
				{
					ArgumentException e = argumentException;
					Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
					throw e;
				}
			}
		}
	}
}