import { useCallback, useEffect, useState } from 'react';
import { motion, useAnimation } from 'framer-motion';
import { IconType } from 'react-icons/lib';
import { BsBook } from 'react-icons/bs';
import { BiStats } from 'react-icons/bi';
import { BiArrowFromRight, BiArrowFromLeft } from 'react-icons/bi';
import { FiSettings } from 'react-icons/fi';
import { NavLink } from 'react-router-dom';

type MenuSection = {
  name: string;
  items: MenuItem[];
};

type MenuItem = {
  title: string;
  to: string;
  icon: IconType;
};

const data: MenuSection[] = [
  {
    name: 'Разделы',
    items: [
      {
        title: 'Абитуриенты',
        icon: BsBook,
        to: '/abiturients',
      },
      {
        title: 'Статистика',
        icon: BiStats,
        to: '/stats',
      },
    ],
  },
  {
    name: 'Настройки',
    items: [
      {
        title: 'Параметры',
        icon: FiSettings,
        to: '/settings',
      },
    ],
  },
];

const LeftNavBar = () => {
  const [active, setActive] = useState(true);
  const controls = useAnimation();
  const controlText = useAnimation();
  const controlTitleText = useAnimation();

  const showMore = useCallback(() => {
    controls.start({
      width: '15rem',
      transition: { duration: 0.001 },
    });
    controlText.start({
      opacity: 1,
      display: 'block',
      transition: { delay: 0.3 },
    });
    controlTitleText.start({
      opacity: 1,
      transition: { delay: 0.3 },
    });

    setActive(true);
  }, [controls, controlText, controlTitleText]);

  const showLess = useCallback(() => {
    controls.start({
      width: '3.5rem',
      transition: { duration: 0.001 },
    });
    controlText.start({
      opacity: 0,
      display: 'none',
    });
    controlTitleText.start({
      opacity: 0,
    });

    setActive(false);
  }, [controls, controlText, controlTitleText]);

  useEffect(() => {
    showMore();
  }, [showMore]);

  return (
    <motion.div
      animate={controls}
      className="relative max-w-[15rem] min-h-screen py-14 border-gray-700 bg-sky-900 text-gray-200 duration-300 group"
    >
      {active && (
        <BiArrowFromRight
          className="hidden absolute top-8 -right-4 bg-sky-900 text-sky-900 fill-white rounded-2xl cursor-pointer hover:bg-white hover:fill-sky-900 group-hover:block"
          size="2rem"
          onClick={showLess}
        />
      )}
      {!active && (
        <BiArrowFromLeft
          className="absolute top-8 -right-4 bg-sky-900 text-sky-900 fill-white rounded-2xl cursor-pointer hover:bg-white hover:fill-sky-900"
          size="2rem"
          onClick={showMore}
        />
      )}
      <div>
        {data.map((group, idx) => (
          <div key={idx} className="my-2">
            <motion.p animate={controlTitleText} className="mb-2 ml-4">
              {group.name}
            </motion.p>

            {group.items.map((item, itemIdx) => (
              <NavLink
                to={item.to}
                key={itemIdx}
                className={({ isActive }) =>
                  `flex items-center px-4 py-2 cursor-pointer hover:bg-gray-200 hover:text-sky-900 ${
                    isActive && 'bg-gray-200 text-sky-900 cursor-default'
                  }`
                }
              >
                <item.icon size="1.5rem" />
                <motion.p
                  animate={controlText}
                  className="ml-4 text-sm font-bold"
                >
                  {item.title}
                </motion.p>
              </NavLink>
            ))}
          </div>
        ))}
      </div>
    </motion.div>
  );
};

export default LeftNavBar;
