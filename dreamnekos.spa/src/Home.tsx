import { Sidebar } from 'flowbite-react';
import { HiChartPie, HiUser, HiViewBoards } from 'react-icons/hi';
import { Outlet, Link } from "react-router-dom";


function Home() {
  return (
      <div className="flex ">
        <div className="flex" id="sidebar">
            <Sidebar aria-label="Default sidebar example">
                <Sidebar.Items>
                    <Sidebar.ItemGroup>
                        <Link to={`/interests`}>
                            <Sidebar.Item icon={HiViewBoards}>
                                Interest
                            </Sidebar.Item>
                        </Link>
                        <Link to={`/interestTypes`}>
                            <Sidebar.Item icon={HiViewBoards}>
                            Interest Type
                            </Sidebar.Item>
                        </Link>
                        <Sidebar.Item href="#" icon={HiUser}>
                            Users
                        </Sidebar.Item>
                    </Sidebar.ItemGroup>
                    <Sidebar.ItemGroup>
                        <Sidebar.Item href="#" icon={HiChartPie}>
                            Statistic
                        </Sidebar.Item>
                    </Sidebar.ItemGroup>
                </Sidebar.Items>
            </Sidebar>
        </div>
        <div className="flex-auto px-4">
            <Outlet />
        </div>
      </div>
  )
}

export default Home
