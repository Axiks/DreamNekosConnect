import React, { useEffect, useState } from 'react';
import { Sidebar } from 'flowbite-react';
import { HiChartPie, HiUser, HiViewBoards } from 'react-icons/hi';
import { getInterestTypes, getInterests } from './services/apiWrapper';
import { InterestResponse, InterestTypeResponse } from './services/openapi';
import InterestTypeView from './InterestTypeView';
import InterestView from './InterestType';

function Home() {
    const [interests, setInterests] = useState<InterestResponse[]>([]);
    const [data, setData] = useState<InterestTypeResponse[]>([]);

      useEffect(() => {
        // declare the data fetching function
        const fetchData = async () => {
          const data = await getInterestTypes();
          console.log(data)
          setData(data)

          const interests = await getInterests();
          console.log(interests)
          setInterests(interests)
        }
      
        // call the function
        fetchData()
          // make sure to catch any error
          .catch(console.error);
      }, [])
      

  return (
      <div className="flex ">
        {/* <EditModal /> */}
        <div className="flex">
            <Sidebar aria-label="Default sidebar example">
                <Sidebar.Items>
                    <Sidebar.ItemGroup>
                        <Sidebar.Item href="#" icon={HiViewBoards}>
                            Interest
                        </Sidebar.Item>
                        <Sidebar.Item href="#" icon={HiViewBoards}>
                            Interest Type
                        </Sidebar.Item>
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
            <InterestView interests={interests} />
            <InterestTypeView InterestTypes={data}  />
        </div>
      </div>
  )
}

export default Home
