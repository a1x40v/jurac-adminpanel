import { Column, usePagination, useTable } from 'react-table';

import { PublishTabView } from '../../../app/models/PublishTab';
import PaginationBar from '../../common/reactTable/PaginationBar';
import ReactTable from '../../common/reactTable/ReactTable';

interface Props {
  columns: Array<Column>;
  data: PublishTabView[];
}

const PublishTabTable: React.FC<Props> = ({ columns, data }) => {
  const tableInstance = useTable(
    {
      columns,
      data,
      initialState: { pageIndex: 0, pageSize: 25 },
    },
    usePagination
  );

  return (
    <div>
      <ReactTable tableInstance={tableInstance} />
      <PaginationBar tableInstance={tableInstance} />
    </div>
  );
};

export default PublishTabTable;
