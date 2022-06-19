interface Props {
  id: string;
  activeTabId: string;
  children: React.ReactNode;
}

const TabContent: React.FC<Props> = ({ id, activeTabId, children }) => {
  const activeClass = activeTabId === id ? '' : 'hidden';

  return <div className={`${activeClass}`}>{children}</div>;
};

export default TabContent;
