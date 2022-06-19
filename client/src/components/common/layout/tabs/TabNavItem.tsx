interface Props {
  id: string;
  title: string;
  activeTabId: string;
  setActiveTab: (id: string) => void;
}

const TabNavItem: React.FC<Props> = ({
  id,
  title,
  activeTabId,
  setActiveTab,
}) => {
  const handleClick = () => {
    setActiveTab(id);
  };

  const activeClass =
    activeTabId === id
      ? 'bg-sky-700 text-white'
      : 'cursor-pointer hover:underline';

  return (
    <li onClick={handleClick} className={`p-3 ${activeClass}`}>
      {title}
    </li>
  );
};
export default TabNavItem;
