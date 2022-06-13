import { TableInstance } from 'react-table';

interface Props {
  tableInstance: TableInstance;
}

const ReactTable: React.FC<Props> = ({ tableInstance }) => {
  const { headerGroups, rows, getTableProps, getTableBodyProps, prepareRow } =
    tableInstance;

  return (
    <>
      <table className="mb-6 rounded-md" {...getTableProps()}>
        <thead className="text-white bg-sky-700">
          {headerGroups.map((headerGroup) => (
            <tr {...headerGroup.getHeaderGroupProps()}>
              {headerGroup.headers.map((column) => (
                <th className="p-3 text-left" {...column.getHeaderProps()}>
                  {column.render('Header')}
                </th>
              ))}
            </tr>
          ))}
        </thead>

        <tbody className="divide-y" {...getTableBodyProps()}>
          {rows.map((row) => {
            prepareRow(row);
            return (
              <tr {...row.getRowProps()}>
                {row.cells.map((cell) => (
                  <td className="p-3" {...cell.getCellProps()}>
                    {cell.render('Cell')}
                  </td>
                ))}
              </tr>
            );
          })}
        </tbody>
      </table>
    </>
  );
};

export default ReactTable;
