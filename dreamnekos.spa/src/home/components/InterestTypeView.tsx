import React, { useContext, useEffect, useState } from 'react';
import { Button, Table } from 'flowbite-react';
import { InterestTypeResponse } from '../../services/openapi';
import { InterestTypeControllContext } from '../context/InterestTypeControllContext';
import EditInterestTypeModal from './EditInterestTypeModal';
import EditInterestTypeProps from './EditInterestTypeModal'

interface InterestTypeViewProps {
    InterestTypes: InterestTypeResponse[];
}

function InterestTypeView(props: InterestTypeViewProps){
    const [editModal, setEditModal] = useState<JSX.Element>();

    const InterestControll = useContext(InterestTypeControllContext);

    const onDelete = (interetstTypeId: string) => {
        InterestControll.deleteInterestType(interetstTypeId);
    };

const closeModal = () => {
    setEditModal(<></>)
}

const onEdit = (interetstTypeId: string) => {
    var modal = <EditInterestTypeModal 
        interestTypeId={interetstTypeId}
        closeModal={ closeModal }/>
    setEditModal(modal)
}

    return(
        <>
        { editModal }
        <Table hoverable={true}>
            <Table.Head>
                <Table.HeadCell>
                Interest type name
                </Table.HeadCell>
                <Table.HeadCell>
                <span className="sr-only">
                    Edit
                </span>
                </Table.HeadCell>
                <Table.HeadCell>
                <span className="sr-only">
                    Delete
                </span>
                </Table.HeadCell>
            </Table.Head>
            <Table.Body className="divide-y">
            {   InterestControll.interestTypes.map((interestType, index) => 
                <Table.Row key={index} className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        {interestType.name}
                    </Table.Cell>
                    <Table.Cell>
                    <Button onClick={() => onEdit(interestType.interestTypeId!)}>
                            Edit
                        </Button>
                    </Table.Cell>
                    <Table.Cell>
                        <Button onClick={() => onDelete(interestType.interestTypeId!)}>
                            Delete
                        </Button>
                    </Table.Cell>
                </Table.Row>
                )}
            </Table.Body>
            </Table>
        </>
    )
}

export default InterestTypeView