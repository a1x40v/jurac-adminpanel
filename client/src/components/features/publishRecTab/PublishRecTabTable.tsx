import { Column, useTable } from 'react-table';

import { PublishRecTabView } from '../../../app/models/PublishRecTab';
import ReactTable from '../../common/reactTable/ReactTable';

interface Props {
  columns: Array<Column>;
  data: PublishRecTabView[];
}

const PublishRecTabTable: React.FC<Props> = ({ columns, data }) => {
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

export default PublishRecTabTable;
