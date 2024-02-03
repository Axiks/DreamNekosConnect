import { Table } from 'flowbite-react';
import { Sidebar } from 'flowbite-react';
import { HiChartPie, HiUser, HiViewBoards } from 'react-icons/hi';
import EditModal from './EditModal';


function Home() {
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
        <Table hoverable={true}>
            <Table.Head>
                <Table.HeadCell>
                Interest name
                </Table.HeadCell>
                <Table.HeadCell>
                Inetest type
                </Table.HeadCell>
                <Table.HeadCell>
                <span className="sr-only">
                    Edit
                </span>
                </Table.HeadCell>
            </Table.Head>
            <Table.Body className="divide-y">
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                    Apple MacBook Pro 17"
                </Table.Cell>
                <Table.Cell>
                    Sliver
                </Table.Cell>
                <Table.Cell>
                    Laptop
                </Table.Cell>
                <Table.Cell>
                    $2999
                </Table.Cell>
                <Table.Cell>
                    <a
                    href="/tables"
                    className="font-medium text-blue-600 hover:underline dark:text-blue-500"
                    >
                    Edit
                    </a>
                </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                    Microsoft Surface Pro
                </Table.Cell>
                <Table.Cell>
                    White
                </Table.Cell>
                <Table.Cell>
                    Laptop PC
                </Table.Cell>
                <Table.Cell>
                    $1999
                </Table.Cell>
                <Table.Cell>
                    <a
                    href="/tables"
                    className="font-medium text-blue-600 hover:underline dark:text-blue-500"
                    >
                    Edit
                    </a>
                </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                    Magic Mouse 2
                </Table.Cell>
                <Table.Cell>
                    Black
                </Table.Cell>
                <Table.Cell>
                    Accessories
                </Table.Cell>
                <Table.Cell>
                    $99
                </Table.Cell>
                <Table.Cell>
                    <a
                    href="/tables"
                    className="font-medium text-blue-600 hover:underline dark:text-blue-500"
                    >
                    Edit
                    </a>
                </Table.Cell>
                </Table.Row>
            </Table.Body>
            </Table>
        </div>
      </div>
  )
}

export default Home
