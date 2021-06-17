import React from 'react';
import { StyleSheet } from 'react-native';
import { Button, Layout, ButtonGroup } from '@ui-kitten/components';
import ImagesViewer from '../../components/ImagesViewer/ImagesViewer';

export const ImagesScreen = ({images, question, classificationHandler = () => {}, skipHandler = () => {}}) => {  
  return (
      <Layout style={styles.layout}>
        <ImagesViewer images={images} question={question}/>
        <ButtonGroup style={styles.buttonGroup} appearance='outline' status='primary'>
          <Button onPress={classificationHandler} style={styles.button}>Classification</Button>
          <Button onPress={skipHandler} style={styles.button}>Skip</Button>
        </ButtonGroup>           
      </Layout>  
  );
};

const styles = StyleSheet.create({
  layout : {
    flex: 1, 
    justifyContent: 'center', 
  },
  buttonGroup: {
    justifyContent: 'center', 
    margin: 2,
  },
});

export default ImagesScreen;