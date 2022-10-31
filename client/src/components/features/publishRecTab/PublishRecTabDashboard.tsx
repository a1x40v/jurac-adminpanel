import ScaleLoader from 'react-spinners/ScaleLoader';

import PublishRecTabList from './PublishRecTabList';
import Tabs from '../../common/layout/tabs/Tabs';
import PublishRecTabDeploy from './PublishRecTabDeploy';

const PublishRecTabDashboard = () => {
  const tabsData = [
    {
      navTitle: 'Список рекомендованных',
      content: <PublishRecTabList />,
    },
    {
      navTitle: 'Неопубликованные изменения',
      content: <PublishRecTabDeploy />,
    },
  ];

  return (
    <div className="flex justify-center w-full py-6 pr-6 pl-9">
      <div className="w-full">
        <h2 className="mb-6 text-xl text-center">
          Рекоммендованные к зачислению
        </h2>
        <Tabs data={tabsData} />
      </div>
    </div>
  );
};

export default PublishRecTabDashboard;
