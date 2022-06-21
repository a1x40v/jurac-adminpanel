import { useCallback, useEffect, useState } from 'react';
import { motion, useAnimation } from 'framer-motion';
import { IconType } from 'react-icons/lib';
import { BsBook, BsList, BsListCheck } from 'react-icons/bs';
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
        title: 'Подавшие',
        icon: BsList,
        to: '/publishtabs',
      },
      {
        title: 'Рекомендованные',
        icon: BsListCheck,
        to: '/publishrectabs',
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
  const [active, setActive] = useState(false);
  const controls = useAnimation();
  const controlText = useAnimation();
  const controlTitleText = useAnimation();

  const showMore = useCallback(() => {
    controls.start({
      width: '15rem',
      minWidth: '15rem',
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
      minWidth: '3.5rem',
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
    // showMore();
  }, [showMore]);

  return (
    <motion.div
      animate={controls}
      style={{ width: '3.5rem', minWidth: '3.5rem' }}
      className="relative min-w-[15rem] min-h-screen py-14 border-gray-700 bg-sky-900 text-gray-200 duration-300 group"
    >
      {active && (
        <BiArrowFromRight
          className="absolute hidden cursor-pointer top-8 -right-4 bg-sky-900 text-sky-900 fill-white rounded-2xl hover:bg-white hover:fill-sky-900 group-hover:block"
          size="2rem"
          onClick={showLess}
        />
      )}
      {!active && (
        <BiArrowFromLeft
          className="absolute cursor-pointer top-8 -right-4 bg-sky-900 text-sky-900 fill-white rounded-2xl hover:bg-white hover:fill-sky-900"
          size="2rem"
          onClick={showMore}
        />
      )}
      <div>
        {data.map((group, idx) => (
          <div key={idx} className="my-2">
            <motion.p
              style={{ opacity: 0 }}
              animate={controlTitleText}
              className="mb-2 ml-4"
            >
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
                  style={{ opacity: 0, display: 'none' }}
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
