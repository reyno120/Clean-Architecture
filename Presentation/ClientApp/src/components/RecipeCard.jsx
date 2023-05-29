import React, { useState } from 'react'
import { Card, CardBody, CardTitle, CardText, Button } from 'reactstrap';
import { Modal, ModalHeader, ModalBody } from 'reactstrap';
import { AdvancedImage, lazyload } from '@cloudinary/react';

export default function RecipeCard(props) {
    const [modal, setModal] = useState(false);

    const toggle = () => setModal(!modal);

    const directions = props.recipe.directions.map(direction =>
        <CardText key={direction.id.value}>
            {direction.stepNumber}. {direction.description}
        </CardText>) 

    var image = props.recipe.imagePublicId ?
        props.cld.image('recipes/' + props.recipe.imagePublicId + '.jpg') :
        props.cld.image('sample');

    return (
        <Card
            style={{
                width: '18rem',
                margin: 'auto'
            }}
        >
            <AdvancedImage
                cldImg={image}
                plugins={[lazyload()]}
            />
            <CardBody>
                <CardTitle tag="h5">
                    {props.recipe.name}
                </CardTitle>
                <CardText>
                    { props.recipe.description }
                </CardText>
                <Button onClick={toggle} color="primary" outline>
                    Directions
                </Button>
            </CardBody>
            <Modal isOpen={modal} toggle={toggle}>
                <ModalHeader>
                    Directions for <strong>{props.recipe.name}</strong>
                </ModalHeader>
                <ModalBody>
                    { directions }
                </ModalBody>
            </Modal>
        </Card>
    );
}