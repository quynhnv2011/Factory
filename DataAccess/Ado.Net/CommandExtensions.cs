using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.Ado.Net
{
    /// <summary>
    /// Extension methods for IDbCommand
    /// </summary>
    public static class CommandExtensions
    {
        /// <summary>
        /// Make it easier to find a command
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="name">Paramater name</param>
        /// <param name="value">Value. Null will be converted to <c>DBNull.Value</c></param>
        public static void AddParameter(this IDbCommand command, string name, object value)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (name == null) throw new ArgumentNullException("name");

            var p = command.CreateParameter();
            p.ParameterName = name;
            p.Value = value ?? DBNull.Value;
            command.Parameters.Add(p);
        }

        public static OracleParameter AddParameter(this IDbCommand command, string name, object value, OracleDbType type)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (name == null) throw new ArgumentNullException("name");

            var p = new OracleParameter(name, type, ParameterDirection.Input) {Value = value};
            command.Parameters.Add(p);
            return p;
        }


        public static OracleParameter AddRefCursorParameter(this IDbCommand command, string name)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (name == null) throw new ArgumentNullException("name");

            var p = new OracleParameter(name, OracleDbType.RefCursor);
            command.Parameters.Add(p);
            return p;
        }
        public static OracleParameter AddOutputParameter(this IDbCommand command, string name)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (name == null) throw new ArgumentNullException("name");
            var p = new OracleParameter();
            p.ParameterName = name;
            p.Direction = ParameterDirection.Output;
            command.Parameters.Add(p);
            return p;
        }

        public static OracleParameter AddOutputParameter(this IDbCommand command, List<string> name, OracleDbType type)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (name == null) throw new ArgumentNullException("name");
            OracleParameter p = new OracleParameter("cur", type);
            p.Direction = ParameterDirection.Output;
            p.Value = name;
            command.Parameters.Add(p);
            return p;
        }
    }
}
