import { useState } from 'react';
import TabContent from './TabContent';
import TabNavItem from './TabNavItem';

interface TabData {
  navTitle: string;
  content: React.ReactNode;
}

type TabDesc = TabData & { id: string };

interface Props {
  data: TabData[];
}

const Tabs: React.FC<Props> = ({ data }) => {
  const [activeTab, setActiveTab] = useState<string>('');

  if (!data.length) return null;

  const tabs: TabDesc[] = data.map((fields, idx) => ({
    id: `tab${idx}`,
    ...fields,
  }));

  if (!activeTab) setActiveTab(tabs[0].id);

  return (
    <div>
      <ul className="flex mb-8 border-b border-sky-700">
        {tabs.map((t) => (
          <TabNavItem
            key={t.id}
            id={t.id}
            title={t.navTitle}
            activeTabId={activeTab}
            setActiveTab={setActiveTab}
          />
        ))}
      </ul>

      <div>
        {tabs.map((t) => (
          <TabContent key={t.id} id={t.id} activeTabId={activeTab}>
            {t.content}
          </TabContent>
        ))}
      </div>
    </div>
  );
};

export default Tabs;
