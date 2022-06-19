import { useParams } from 'react-router-dom';
import Tabs from '../../common/layout/tabs/Tabs';
import AbiturientData from './AbiturientData';

const AbiturientDetail = () => {
  let { id } = useParams();
  const userId = Number(id);

  const tabsData = [
    {
      navTitle: 'Данные',
      content: <AbiturientData userId={userId} />,
    },
    {
      navTitle: 'Публиковать в списке подавших',
      content: <p>Tab 2</p>,
    },
    {
      navTitle: 'Публиковать в списке рекомендованных к зачислению',
      content: <p>Tab 3</p>,
    },
  ];

  return (
    <div className="min-w-[1200px] font-nanito">
      <Tabs data={tabsData} />
    </div>
  );
};

export default AbiturientDetail;
