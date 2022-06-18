import { Column, useTable } from 'react-table';

import { PublishTabView } from '../../../app/models/PublishTab';
import ReactTable from '../../common/reactTable/ReactTable';

interface Props {
  columns: Array<Column>;
  data: PublishTabView[];
}

const PublishTabTable: React.FC<Props> = ({ columns, data }) => {
  const tableInstace = useTable({
    columns,
    data,
  });

  return (
    <div>
      <ReactTable tableInstance={tableInstace} />
    </div>
  );
};

export default PublishTabTable;
